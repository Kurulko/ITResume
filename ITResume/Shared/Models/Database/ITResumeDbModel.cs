﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public abstract class ITResumeDbModel : IDbModel
{
    [Key]
    public long Id { get; set; }
}
