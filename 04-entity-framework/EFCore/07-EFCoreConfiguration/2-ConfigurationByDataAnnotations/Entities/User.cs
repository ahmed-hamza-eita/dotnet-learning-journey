using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2_ConfigurationByDataAnnotations
{

    [Table("tblUsers")]
    class User
    {
        [Column("UserId")]
        public int  Id { get; set; }
        public string Username { get; set; }
    }
}
