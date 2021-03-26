﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Models
{
    public class TripLogContext : DbContext
    {

        public TripLogContext(DbContextOptions<TripLogContext> options)
            : base(options) { }

        public DbSet<Trip> Trips { get; set; }

    }
}
