[System.Serializable]
public class Packet
{
    public LastData beforeData;
    public string codedData;

    public Packet(LastData beforeData, string codedData)
    {
        this.beforeData = beforeData;
        this.codedData = codedData;
    }
}
