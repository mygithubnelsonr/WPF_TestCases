﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_Testcase.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyJukeboxEntities : DbContext
    {
        public MyJukeboxEntities()
            : base("name=MyJukeboxEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tSong> tSongs { get; set; }
        public virtual DbSet<vSongs> vSongs { get; set; }
        public virtual DbSet<tPlaylists> tPlaylists { get; set; }
        public virtual DbSet<tPLentries> tPLentries { get; set; }
        public virtual DbSet<vPlaylistSongs> vPlaylistSongs { get; set; }
        public virtual DbSet<tGenres> tGenres { get; set; }
    }
}
