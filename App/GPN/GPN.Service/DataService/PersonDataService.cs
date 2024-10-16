using GPN.Contract.Filters;
using GPN.Contract.Models;
using GPN.Db.Interface;

namespace GPN.Service.DataService
{
    public class PersonDataService(IRepository<DB.Model.Person> personRepository)
    {
        private readonly IRepository<DB.Model.Person> _personRepository = personRepository;

        public async Task<Contract.Models.Response<EntityList<Contract.Models.Person>>> GetUserAsync(PersonFilter personFilter)
        {
            CancellationTokenSource cts = new();

            try
            {
                var result = await _personRepository.GetAsync(MapFilter(personFilter), cts.Token);
                if (result == null)
                {
                    return Response<EntityList<Person>>.Error($"Ошибка при получении списка персонажей");
                }

                return Response<EntityList<Person>>.Ok(new EntityList<Person>(result.Data.Select(s => MapUserItem(s)).ToList(), result.PageCount, personFilter.Page ?? 0, personFilter.Size ?? 0));

            }
            catch (Exception ex)
            {
                return Response<EntityList<Person>>.Error(ex.Message);
            }
        }

        private static DB.Model.Filter<DB.Model.Person> MapFilter(PersonFilter personFilter)
        {
            return new DB.Model.Filter<DB.Model.Person>()
            {
                Page = personFilter.Page,
                Size = personFilter.Size,
                Sort = personFilter.Sort,
                Selector = prs => (personFilter.Name == null || prs.Name == personFilter.Name) 
                    && (personFilter.NoneField == null || prs.NoneField == personFilter.NoneField)
            };
        }

        //todo: маппинг всех полей
        private static Contract.Models.Person MapUserItem(DB.Model.Person result)
        {
            return new Contract.Models.Person()
            {
                Id = result.Id,
                Name = result.NoneField,
            };
        }
    }
}
