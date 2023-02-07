using _.UniveraHiringChallengeBusines.Services.Abstractions;

using _.UniveraHiringChallengeData.UnitOfWorks.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Concretes
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddCountry(CountryDTO country)
        {
            Country country1 = new Country()
            {
                CountryName = country.CountryName,
                CountryImageUrl = country.CountryImageUrl
            };
            await unitOfWork.GetRepository<Country>().AddAsync(country1);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<Country>> ListCountry()
        {
            var country = await unitOfWork.GetRepository<Country>().GetAllAsync();
            return country;
        }
    }
}
