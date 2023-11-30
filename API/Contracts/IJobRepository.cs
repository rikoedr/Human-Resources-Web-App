﻿using API.Models;

namespace API.Contracts;

public interface IJobRepository : IGeneralRepository<Job>
{
    public Job? GetByName(string name);
    public Job? GetByCode(string code);
}
