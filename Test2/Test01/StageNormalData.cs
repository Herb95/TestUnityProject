public class StageNormalData : StageData {

    public int Id { get; set; }
    public string Name { get; set; }

    public StageNormalData () {

    }

    public StageNormalData (int id, string name) {
        this.Id = id;
        this.Name = name;
    }
}