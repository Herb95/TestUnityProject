public class StageDayrobberData : StageData {
    public int Id { get; set; }
    public string Name { get; set; }
    public int bossId { get; set; }
    public StageDayrobberData () {

    }

    public StageDayrobberData (int id, string name) {
        this.Id = id;
        this.Name = name;
        this.bossId = id + 1;
    }
}