﻿using System.Collections.Generic;
using System.Linq;
using PotatoPortail.Migrations;

namespace PotatoPortail.ViewModels.PlanCadre
{
    public class StructureViewModel
    {
        public Models.PlanCadre PlanCadre { get; set; }
        public ICollection<ElementEnoncePlanCadre> ElementEnoncePlanCadres { get; set; }

        public int RecupererIdPlanCadreElement(int idPlanCadreCompetence, int idElement)
        {
            BdPortail db = new BdPortail();

            var idsPlanCadreElement = from planCadreElement in db.PlanCadreElement
                where planCadreElement.idPlanCadreCompetence == idPlanCadreCompetence &&
                      planCadreElement.idElement == idElement
                select planCadreElement.idElement;

            var idPlanCadreElement = idsPlanCadreElement.First();

            return idPlanCadreElement;
        }
    }
}