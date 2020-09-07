using System.Data;
using AutoMapper;
using ITP_Cli.Engine.Models;

namespace ITP_Cli.Engine.Mapping
{
    public class TsvItemProfile : Profile
    {
        public TsvItemProfile()
        {
            IMappingExpression<DataRow, TsvItem> mappingExpression;

            mappingExpression = CreateMap<DataRow, TsvItem>();
            mappingExpression.ForMember(d => d.Project, o => o.MapFrom(s => s["Project"]));
            mappingExpression.ForMember(d => d.Description, o => o.MapFrom(s => s["Description"]));
            mappingExpression.ForMember(d => d.StartDate, o => o.MapFrom(s => s["Start date"]));
            mappingExpression.ForMember(d => d.Category, o => o.MapFrom(s => s["Category"]));
            mappingExpression.ForMember(d => d.Responsible, o => o.MapFrom(s => s["Responsible"]));
            mappingExpression.ForMember(d => d.SavingAmount, o => o.MapFrom<SavingAmountNullValueResolver>());
            mappingExpression.ForMember(d => d.Currency, o => o.MapFrom<CurrencyNullValueResolver>());
            mappingExpression.ForMember(d => d.Complexity, o => o.MapFrom(s => s["Complexity"]));
        }

        private class SavingAmountNullValueResolver : IValueResolver<DataRow, TsvItem, string>
        {
            public string Resolve(DataRow source, TsvItem destination, string destMember, ResolutionContext context)
            {
                var data = source["Savings amount"].ToString();
                return data == "NULL" ? "" : data;
            }
        }

        private class CurrencyNullValueResolver : IValueResolver<DataRow, TsvItem, string>
        {
            public string Resolve(DataRow source, TsvItem destination, string destMember, ResolutionContext context)
            {
                var data = source["Currency"].ToString();
                return data == "NULL" ? "" : data;
            }
        }
    }
}