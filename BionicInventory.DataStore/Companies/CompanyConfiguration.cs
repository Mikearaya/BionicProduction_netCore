/*
 * @CreateTime: Sep 29, 2018 8:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 29, 2018 8:38 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BionicInventory.DataStore.Companies {
    public class CompanyConfiguration : IEntityTypeConfiguration<Company> {
        public void Configure (EntityTypeBuilder<Company> builder) {
            
            builder.ToTable ("COMPANY");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.City)
                .IsRequired ()
                .HasColumnName ("city")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Country)
                .IsRequired ()
                .HasColumnName ("country")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Location)
                .IsRequired ()
                .HasColumnName ("location")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.SubCity)
                .IsRequired ()
                .HasColumnName ("sub_city")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Tin)
                .IsRequired ()
                .HasColumnName ("TIN")
                .HasColumnType ("varchar(12)");
        }
    }
}