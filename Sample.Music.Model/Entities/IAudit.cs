namespace Sample.Music.Model.Entities
{
    public interface IAudit
    {
		public DateTime CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime ModifyDate { get; set; }
		public string ModifiedBy { get; set; }
	}
}