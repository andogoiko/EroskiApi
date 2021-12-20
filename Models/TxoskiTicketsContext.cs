using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TxoskiApi.Models;

    public class TxoskiTicketsContext : DbContext
    {
        public TxoskiTicketsContext (DbContextOptions<TxoskiTicketsContext> options)
            : base(options)
        {
        }

        public DbSet<TxoskiApi.Models.Ticket> Ticket { get; set; }
    }
