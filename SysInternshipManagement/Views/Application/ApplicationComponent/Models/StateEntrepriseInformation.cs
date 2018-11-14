using System.Linq;
using SysInternshipManagement.Migrations;
using SysInternshipManagement.Models;

namespace SysInternshipManagement.Views.Application.ApplicationComponent.Models
{
    public class StateEntrepriseInformation
    {
        private readonly DatabaseContext _bd = new DatabaseContext();
        private SysInternshipManagement.Models.Stage _stage;
        private Contact _contact;

        public StateEntrepriseInformation(SysInternshipManagement.Models.Stage stage, Contact contact)
        {
            _stage = stage;
            _contact = contact;
        }
    }
}