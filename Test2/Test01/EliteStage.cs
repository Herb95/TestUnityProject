public class EliteStage : StageData {
    public int Id { get; set; }
    public string Name { get; set; }

    public EliteStage () {

    }

    public EliteStage (int id, string name) {
        this.Id = id;
        this.Name = name;
    }
}