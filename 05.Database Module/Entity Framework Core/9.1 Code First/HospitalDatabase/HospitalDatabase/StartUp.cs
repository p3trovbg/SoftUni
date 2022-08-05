namespace P01_HospitalDatabase 
{
    using AutoMapper;
    using HospitalDatabase;
    using P01_HospitalDatabase.Data;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<HospitalProfile>());

            var dbContext = new HospitalContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
