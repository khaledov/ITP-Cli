using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DomainValidation.Interfaces.Validation;
using ITP_Cli.Engine.Models;
using ITP_Cli.Engine.Queries;
using ITP_Cli.Infra.Bus;
using ITP_Cli.Infra.Notifications;
using LumenWorks.Framework.IO.Csv;
using MediatR;

namespace ITP_Cli.Engine.QueryHandlers
{
    public class ParserQueryHandler : IRequestHandler<ParserQuery, ParserQueryResult>
    {
        private readonly IMediatorHandler _bus;

        private readonly IMapper _mapper;

        private readonly IValidator<TsvItem> _parserValidator;

        public ParserQueryHandler(IMediatorHandler bus,
            IMapper mapper,
            IValidator<TsvItem> parserValidator)
        {
            _bus = bus;
            _mapper = mapper;
            _parserValidator = parserValidator;
        }

        public async Task<ParserQueryResult> Handle(ParserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultSet = new ParserQueryResult();

                //If file not exist then system fires domain notificatin event for other listeners
                if (!File.Exists(request.FilePath))
                    await _bus.RaiseEvent(
                        new DomainErrorNotification($"'{request.FilePath}'\tSpecified file does not exist"));

                //read TSV file using "LumenWorks.Framework.IO.Csv" nuget
                var fileContent = File.ReadAllText(request.FilePath);
                using (var csv = new CachedCsvReader(new StringReader(fileContent), true, '\t'))
                {
                    IDataReader dataReader = csv;
                    resultSet.Headers = csv.GetFieldHeaders();

                    var dt = new DataTable();
                    dt.Load(dataReader);

                    if (request.Sort.HasValue && request.Sort.Value)
                        SortData(ref dt, "Start date ASC");

                    //Automapper to map from List<DataRow> to List<TsvItem>
                    var listObject = _mapper.Map<List<DataRow>, List<TsvItem>>(dt.Rows.Cast<DataRow>().ToList());

                    Validate(listObject);

                    //filter list depending on specific project value if any
                    resultSet.Records = request.Project.HasValue
                        ? listObject.FindAll(item => int.Parse(item.Project) == request.Project)
                        : listObject;

                    //return query result to the invoker
                    return await Task.FromResult(resultSet);
                }
            }
            catch (Exception ex)
            {
                ConsoleWriter.WriteException(ex);
                return await Task.FromResult<ParserQueryResult>(null);
            }
        }

        private void SortData(ref DataTable dataRecords, string sortExpr)
        {
            var dv = dataRecords.DefaultView;
            dv.Sort = sortExpr;
            dataRecords = dv.ToTable();
        }

        private void Validate(List<TsvItem> listObject)
        {
            listObject.ForEach(item =>
            {
                var validation = _parserValidator.Validate(item);
                if (!validation.IsValid)
                    validation.Erros.ToList().ForEach(e =>
                        _bus.RaiseEvent(
                            new DomainErrorNotification(
                                $" {e.Message}\nError occured during readin this record ==>'{item}'")));
            });
        }
    }
}