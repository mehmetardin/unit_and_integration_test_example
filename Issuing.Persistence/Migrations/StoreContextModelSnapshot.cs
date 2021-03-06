// <auto-generated />
using Issuing.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Issuing.Persistence.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Issuing.Domain.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bin")
                        .HasColumnType("TEXT");

                    b.Property<long>("BinRangeGuid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardNo")
                        .HasColumnType("TEXT");

                    b.Property<long>("Guid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("INTEGER");

                    b.Property<long>("LastUpdated")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
