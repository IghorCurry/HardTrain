﻿using HardTrain.DAL.Entities.ExersiceEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Models;

public record ExersiceCreateModel
{
    public string Title { get; init; }
    public string Description { get; init; }
    public Category Category { get; init; }
}