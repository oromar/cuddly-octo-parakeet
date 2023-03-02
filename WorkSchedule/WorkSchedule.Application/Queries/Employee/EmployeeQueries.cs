﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.Commands.Employee;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.Queries.Employee
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly IRepository<Domain.Models.Employee> repository;

        public EmployeeQueries(IRepository<Domain.Models.Employee> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<EmployeeDTO>> ListEmployees()
        {
            return repository.AsQueryable()
                .OrderBy(a => a.CreationTime)
                .Select(a => new EmployeeDTO
                {
                    Name = a.Name,
                    Code = a.EmployeeCode,
                    CreationTime = a.CreationTime,
                    FirstSchedule = a.FirstSchedule,
                })
                .AsEnumerable();
        }

        public async Task<IEnumerable<EmployeeDTO>> SearchEmployees(string criteria)
        {
            var searchText = criteria?.ToLower().RemoveDiacritics();
            var dbQuery = repository.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchText))
                dbQuery = dbQuery.Where(a => a.SearchText.ToLower().Contains(searchText));
            return dbQuery
                .OrderBy(a => a.CreationTime)
                .Select(a => new EmployeeDTO
                {
                    Name = a.Name,
                    Code = a.EmployeeCode,
                    CreationTime = a.CreationTime,
                    FirstSchedule = a.FirstSchedule,
                })
                .AsEnumerable();
        }
    }
}
