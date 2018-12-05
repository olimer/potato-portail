namespace PotatoPortail.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BdPortail : DbContext
    {
        public BdPortail()
            : base("name=BDPortail")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ActiviteApprentissage> ActiviteApprentissage { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Caracteristiques> Caracteristiques { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContenuSection> ContenuSection { get; set; }
        public virtual DbSet<ContexteRealisation> ContexteRealisation { get; set; }
        public virtual DbSet<Cours> Cours { get; set; }
        public virtual DbSet<CriterePerformance> CriterePerformance { get; set; }
        public virtual DbSet<Departement> Departement { get; set; }
        public virtual DbSet<DevisMinistere> DevisMinistere { get; set; }
        public virtual DbSet<ElementCompetence> ElementCompetence { get; set; }
        public virtual DbSet<ElementConnaissance> ElementConnaissance { get; set; }
        public virtual DbSet<EnonceCompetence> EnonceCompetence { get; set; }
        public virtual DbSet<Entraineurs> Entraineurs { get; set; }
        public virtual DbSet<Entreprise> Entreprise { get; set; }
        public virtual DbSet<EnvironnementPhysique> EnvironnementPhysique { get; set; }
        public virtual DbSet<Equipes> Equipes { get; set; }
        public virtual DbSet<Etudiant> Etudiant { get; set; }
        public virtual DbSet<GrilleCours> GrilleCours { get; set; }
        public virtual DbSet<HistoriqueRangs> HistoriqueRangs { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Jeux> Jeux { get; set; }
        public virtual DbSet<Joueurs> Joueurs { get; set; }
        public virtual DbSet<LieuDeLaReunion> LieuDeLaReunion { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MembreESports> MembreESports { get; set; }
        public virtual DbSet<ModeleOrdreDuJour> ModeleOrdreDuJour { get; set; }
        public virtual DbSet<NomSection> NomSection { get; set; }
        public virtual DbSet<OrdreDuJour> OrdreDuJour { get; set; }
        public virtual DbSet<PlanCadre> PlanCadre { get; set; }
        public virtual DbSet<PlanCadreCompetence> PlanCadreCompetence { get; set; }
        public virtual DbSet<PlanCadreElement> PlanCadreElement { get; set; }
        public virtual DbSet<PlanCadrePrealable> PlanCadrePrealable { get; set; }
        public virtual DbSet<PlanCours> PlanCours { get; set; }
        public virtual DbSet<PlanCoursUtilisateur> PlanCoursUtilisateur { get; set; }
        public virtual DbSet<Poste> Poste { get; set; }
        public virtual DbSet<Preference> Preference { get; set; }
        public virtual DbSet<Profils> Profils { get; set; }
        public virtual DbSet<Programme> Programme { get; set; }
        public virtual DbSet<Rangs> Rangs { get; set; }
        public virtual DbSet<RessourceDIdactique> RessourceDIdactique { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<SousActiviteApprentissage> SousActiviteApprentissage { get; set; }
        public virtual DbSet<SousElementConnaissance> SousElementConnaissance { get; set; }
        public virtual DbSet<SousEnvironnementPhysique> SousEnvironnementPhysique { get; set; }
        public virtual DbSet<SousPointSujet> SousPointSujet { get; set; }
        public virtual DbSet<SousRessourceDIdactique> SousRessourceDIdactique { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<StatutPrealable> StatutPrealable { get; set; }
        public virtual DbSet<Statuts> Statuts { get; set; }
        public virtual DbSet<StatutStage> StatutStage { get; set; }
        public virtual DbSet<SujetPointPrincipal> SujetPointPrincipal { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypePlanCadre> TypePlanCadre { get; set; }
        public virtual DbSet<AccesProgramme> AccesProgramme { get; set; }
        public virtual DbSet<PlanCoursDepart> PlanCoursDepart { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiviteApprentissage>()
                .Property(e => e.DescActivite)
                .IsUnicode(false);

            modelBuilder.Entity<ActiviteApprentissage>()
                .HasMany(e => e.SousActiviteApprentissage)
                .WithRequired(e => e.ActiviteApprentissage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.PlanCoursUtilisateur)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.idPlanCoursUtilisateur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Caracteristiques>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Caracteristiques)
                .HasForeignKey(e => e.IdCaracteristique);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Stage)
                .WithOptional(e => e.Contact)
                .HasForeignKey(e => e.Contact_IdContact);

            modelBuilder.Entity<ContenuSection>()
                .HasMany(e => e.PlanCours)
                .WithMany(e => e.ContenuSection)
                .Map(m => m.ToTable("TexteSection").MapLeftKey("idContenuSection").MapRightKey("idPlanCours"));

            modelBuilder.Entity<ContexteRealisation>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.PlanCours)
                .WithRequired(e => e.Cours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CriterePerformance>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Departement>()
                .Property(e => e.Discipline)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Departement>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Departement>()
                .HasMany(e => e.AccesProgramme)
                .WithRequired(e => e.Departement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departement>()
                .HasMany(e => e.DevisMinistere)
                .WithRequired(e => e.Departement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departement>()
                .HasMany(e => e.PlanCoursDepart)
                .WithRequired(e => e.Departement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DevisMinistere>()
                .Property(e => e.Annee)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevisMinistere>()
                .Property(e => e.CodeSpecialisation)
                .IsUnicode(false);

            modelBuilder.Entity<DevisMinistere>()
                .Property(e => e.Specialisation)
                .IsUnicode(false);

            modelBuilder.Entity<DevisMinistere>()
                .Property(e => e.NbUnite)
                .IsUnicode(false);

            modelBuilder.Entity<DevisMinistere>()
                .Property(e => e.Condition)
                .IsUnicode(false);

            modelBuilder.Entity<DevisMinistere>()
                .Property(e => e.Sanction)
                .IsUnicode(false);

            modelBuilder.Entity<DevisMinistere>()
                .Property(e => e.DocMinistere)
                .IsUnicode(false);

            modelBuilder.Entity<DevisMinistere>()
                .Property(e => e.Discipline)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevisMinistere>()
                .HasMany(e => e.EnonceCompetence)
                .WithRequired(e => e.DevisMinistere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DevisMinistere>()
                .HasMany(e => e.Programme)
                .WithRequired(e => e.DevisMinistere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ElementCompetence>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ElementCompetence>()
                .HasMany(e => e.CriterePerformance)
                .WithRequired(e => e.ElementCompetence)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ElementCompetence>()
                .HasMany(e => e.PlanCadreElement)
                .WithRequired(e => e.ElementCompetence)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ElementConnaissance>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EnonceCompetence>()
                .Property(e => e.CodeCompetence)
                .IsUnicode(false);

            modelBuilder.Entity<EnonceCompetence>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EnonceCompetence>()
                .HasMany(e => e.ContexteRealisation)
                .WithRequired(e => e.EnonceCompetence)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnonceCompetence>()
                .HasMany(e => e.ElementCompetence)
                .WithRequired(e => e.EnonceCompetence)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnonceCompetence>()
                .HasMany(e => e.PlanCadreCompetence)
                .WithRequired(e => e.EnonceCompetence)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entraineurs>()
                .HasMany(e => e.Equipes)
                .WithMany(e => e.Entraineurs)
                .Map(m => m.ToTable("EntraineurEquipes").MapLeftKey("IdEntraineur").MapRightKey("IdEquipe"));

            modelBuilder.Entity<Entreprise>()
                .HasMany(e => e.Contact)
                .WithRequired(e => e.Entreprise)
                .HasForeignKey(e => e.Entreprise_IdEntreprise);

            modelBuilder.Entity<EnvironnementPhysique>()
                .Property(e => e.NomEnvPhys)
                .IsUnicode(false);

            modelBuilder.Entity<EnvironnementPhysique>()
                .HasMany(e => e.SousEnvironnementPhysique)
                .WithRequired(e => e.EnvironnementPhysique)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipes>()
                .HasMany(e => e.Joueurs)
                .WithMany(e => e.Equipes)
                .Map(m => m.ToTable("EquipeJoueurs").MapLeftKey("IdEquipe").MapRightKey("IdJoueur"));

            modelBuilder.Entity<Etudiant>()
                .HasMany(e => e.Application)
                .WithRequired(e => e.Etudiant)
                .HasForeignKey(e => e.Etudiant_IdEtudiant);

            modelBuilder.Entity<GrilleCours>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<GrilleCours>()
                .HasMany(e => e.Cours)
                .WithRequired(e => e.GrilleCours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Items>()
                .HasMany(e => e.Joueurs)
                .WithMany(e => e.Items)
                .Map(m => m.ToTable("JoueurItems").MapLeftKey("IdItem").MapRightKey("IdJoueur"));

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.Caracteristiques)
                .WithRequired(e => e.Jeux)
                .HasForeignKey(e => e.IdJeu);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.Equipes)
                .WithRequired(e => e.Jeux)
                .HasForeignKey(e => e.IdJeu);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.Profils)
                .WithRequired(e => e.Jeux)
                .HasForeignKey(e => e.IdJeu);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.Rangs)
                .WithRequired(e => e.Jeux)
                .HasForeignKey(e => e.IdJeu);

            modelBuilder.Entity<Joueurs>()
                .HasMany(e => e.HistoriqueRangs)
                .WithRequired(e => e.Joueurs)
                .HasForeignKey(e => e.IdJoueur);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Stage)
                .WithOptional(e => e.Location)
                .HasForeignKey(e => e.Location_IdLocation);

            modelBuilder.Entity<MembreESports>()
                .HasMany(e => e.Joueurs)
                .WithRequired(e => e.MembreESports)
                .HasForeignKey(e => e.IdMembreESports);

            modelBuilder.Entity<MembreESports>()
                .HasMany(e => e.Profils)
                .WithRequired(e => e.MembreESports)
                .HasForeignKey(e => e.IdMembreESports);

            modelBuilder.Entity<ModeleOrdreDuJour>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<ModeleOrdreDuJour>()
                .Property(e => e.PointPrincipal)
                .IsUnicode(false);

            modelBuilder.Entity<ModeleOrdreDuJour>()
                .HasMany(e => e.OrdreDuJour)
                .WithRequired(e => e.ModeleOrdreDuJour)
                .HasForeignKey(e => e.IdModeleOrdreDuJour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NomSection>()
                .Property(e => e.titreSection)
                .IsUnicode(false);

            modelBuilder.Entity<NomSection>()
                .Property(e => e.obligatoire)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NomSection>()
                .HasMany(e => e.ContenuSection)
                .WithRequired(e => e.NomSection)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NomSection>()
                .HasMany(e => e.PlanCoursDepart)
                .WithRequired(e => e.NomSection)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdreDuJour>()
                .Property(e => e.TitreOdJ)
                .IsUnicode(false);

            modelBuilder.Entity<OrdreDuJour>()
                .Property(e => e.HeureDebutReunion)
                .IsUnicode(false);

            modelBuilder.Entity<OrdreDuJour>()
                .Property(e => e.HeureFinReunion)
                .IsUnicode(false);

            modelBuilder.Entity<OrdreDuJour>()
                .Property(e => e.LieuReunionODJ)
                .IsUnicode(false);

            modelBuilder.Entity<OrdreDuJour>()
                .HasMany(e => e.SujetPointPrincipal)
                .WithRequired(e => e.OrdreDuJour)
                .HasForeignKey(e => e.IdOrdreDuJour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCadre>()
                .Property(e => e.NumeroCours)
                .IsUnicode(false);

            modelBuilder.Entity<PlanCadre>()
                .Property(e => e.TitreCours)
                .IsUnicode(false);

            modelBuilder.Entity<PlanCadre>()
                .Property(e => e.IndicationPedago)
                .IsUnicode(false);

            modelBuilder.Entity<PlanCadre>()
                .HasMany(e => e.Cours)
                .WithRequired(e => e.PlanCadre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCadre>()
                .HasMany(e => e.EnvironnementPhysique)
                .WithRequired(e => e.PlanCadre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCadre>()
                .HasMany(e => e.RessourceDIdactique)
                .WithRequired(e => e.PlanCadre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCadre>()
                .HasMany(e => e.PlanCadreCompetence)
                .WithRequired(e => e.PlanCadre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCadre>()
                .HasMany(e => e.PlanCadrePrealable)
                .WithRequired(e => e.PlanCadre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCadreCompetence>()
                .HasMany(e => e.PlanCadreElement)
                .WithRequired(e => e.PlanCadreCompetence)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCadreElement>()
                .HasMany(e => e.ActiviteApprentissage)
                .WithRequired(e => e.PlanCadreElement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCours>()
                .HasMany(e => e.PlanCoursDepart)
                .WithRequired(e => e.PlanCours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCours>()
                .HasMany(e => e.PlanCoursUtilisateur)
                .WithRequired(e => e.PlanCours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanCoursUtilisateur>()
                .Property(e => e.bureauProf)
                .IsUnicode(false);

            modelBuilder.Entity<PlanCoursUtilisateur>()
                .Property(e => e.poste)
                .IsUnicode(false);

            modelBuilder.Entity<Poste>()
                .HasMany(e => e.Stage)
                .WithOptional(e => e.Poste)
                .HasForeignKey(e => e.Poste_IdPoste);

            modelBuilder.Entity<Preference>()
                .HasMany(e => e.Etudiant)
                .WithOptional(e => e.Preference)
                .HasForeignKey(e => e.Preference_IdPreference);

            modelBuilder.Entity<Preference>()
                .HasMany(e => e.Location)
                .WithOptional(e => e.Preference)
                .HasForeignKey(e => e.Preference_IdPreference);

            modelBuilder.Entity<Profils>()
                .HasMany(e => e.Joueurs)
                .WithRequired(e => e.Profils)
                .HasForeignKey(e => e.IdProfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Programme>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Programme>()
                .Property(e => e.Annee)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Programme>()
                .HasMany(e => e.PlanCadre)
                .WithRequired(e => e.Programme)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rangs>()
                .HasMany(e => e.HistoriqueRangs)
                .WithRequired(e => e.Rangs)
                .HasForeignKey(e => e.IdRang);

            modelBuilder.Entity<RessourceDIdactique>()
                .Property(e => e.NomRessource)
                .IsUnicode(false);

            modelBuilder.Entity<RessourceDIdactique>()
                .HasMany(e => e.SousRessourceDIdactique)
                .WithRequired(e => e.RessourceDIdactique)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Session>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Session>()
                .HasMany(e => e.Cours)
                .WithRequired(e => e.Session)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SousActiviteApprentissage>()
                .Property(e => e.NomSousActivite)
                .IsUnicode(false);

            modelBuilder.Entity<SousElementConnaissance>()
                .Property(e => e.DescSousElement)
                .IsUnicode(false);

            modelBuilder.Entity<SousEnvironnementPhysique>()
                .Property(e => e.NomSousEnvPhys)
                .IsUnicode(false);

            modelBuilder.Entity<SousPointSujet>()
                .Property(e => e.SujetSousPoint)
                .IsUnicode(false);

            modelBuilder.Entity<SousRessourceDIdactique>()
                .Property(e => e.NomSousRessource)
                .IsUnicode(false);

            modelBuilder.Entity<Stage>()
                .HasMany(e => e.Application)
                .WithRequired(e => e.Stage)
                .HasForeignKey(e => e.Stage_IdStage);

            modelBuilder.Entity<StatutPrealable>()
                .Property(e => e.Statut)
                .IsUnicode(false);

            modelBuilder.Entity<StatutPrealable>()
                .HasMany(e => e.PlanCadrePrealable)
                .WithRequired(e => e.StatutPrealable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statuts>()
                .HasMany(e => e.Jeux)
                .WithRequired(e => e.Statuts)
                .HasForeignKey(e => e.IdStatuts);

            modelBuilder.Entity<StatutStage>()
                .HasMany(e => e.Stage)
                .WithOptional(e => e.StatutStage)
                .HasForeignKey(e => e.StatutStage_IdStatutStage);

            modelBuilder.Entity<SujetPointPrincipal>()
                .Property(e => e.SujetPoint)
                .IsUnicode(false);

            modelBuilder.Entity<SujetPointPrincipal>()
                .HasMany(e => e.SousPointSujet)
                .WithRequired(e => e.SujetPointPrincipal)
                .HasForeignKey(e => e.IdSujetPointPrincipal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypePlanCadre>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<TypePlanCadre>()
                .HasMany(e => e.PlanCadre)
                .WithRequired(e => e.TypePlanCadre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccesProgramme>()
                .Property(e => e.Discipline)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PlanCoursDepart>()
                .Property(e => e.discipline)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}