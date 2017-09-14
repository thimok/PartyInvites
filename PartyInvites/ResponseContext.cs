using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Models;

namespace PartyInvites
{
    public class ResponseContext : DbContext
    {
	    public ResponseContext(DbContextOptions<ResponseContext> options) : base(options)
	    {
		    
	    }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<GuestResponse>().HasKey(e => e.Email); //Set the primary key to the Email field (because there is no ID field)
	    }

		public virtual DbSet<GuestResponse> Responses { get; set; }
    }
}
