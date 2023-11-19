using CiudadanosSanos.Models;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Data
{
	public class CiudadanosSanosContext: DbContext
	{
		public CiudadanosSanosContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<MedicalAttention> MedicalAttentions { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(
		//		"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CiudadanosSanosDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
		//		);
		//}
	}
}
