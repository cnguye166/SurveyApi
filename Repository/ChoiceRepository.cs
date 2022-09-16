﻿using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class ChoiceRepository : RepositoryBase<Choice>, IChoiceRepository
    {
        public ChoiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
