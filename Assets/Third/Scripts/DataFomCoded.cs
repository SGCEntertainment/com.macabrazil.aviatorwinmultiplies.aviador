using System.Collections.Generic;

[System.Serializable]
public class DataFomCoded
{
	public string huw_protocol;

	public string huw_sim_geo;

	public string huw_bundle;

	public string huw_amidentificator;

    public string huw_afidentificator;

    public string huw_googleID;

	public string huw_subcodename;

	public string bundle_prop;

	public string subcodename_prop;

	public string domen_prop;

	public string space_prop;

	public string requestCampaign_prop;

    public static bool operator ==(DataFomCoded first, DataFomCoded second) => first == second;
    public static bool operator !=(DataFomCoded first, DataFomCoded _) => first.huw_sim_geo != "[none]";

    public DataFomCoded()
    {
        huw_protocol = "[none]";
        huw_sim_geo = "[none]";
        huw_bundle = "[none]";
        huw_amidentificator = "[none]";
        huw_afidentificator = "[none]";
        huw_googleID = "[none]";
        huw_subcodename = "[none]";
        bundle_prop = "[none]";
        subcodename_prop = "[none]";
        domen_prop = "[none]";
        space_prop = "[none]";
        requestCampaign_prop = "[none]";
    }

    public DataFomCoded(string protocol, string sim_geo, string bundle, string amidentificator, string afidentificator, string googleid, string subcodename, string appref, string dl_url, string dl_url2, string bundle_prop, string subcodename_prop, string domen_prop, string space_prop, string requestCampaign_prop):this()
    {
        huw_protocol = protocol;
        huw_sim_geo = sim_geo;
        huw_bundle = bundle;
        huw_amidentificator = amidentificator;
        huw_afidentificator = afidentificator;
        huw_googleID = googleid;
        huw_subcodename = subcodename;
        this.bundle_prop = bundle_prop;
        this.subcodename_prop = subcodename_prop;
        this.domen_prop = domen_prop;
        this.space_prop = space_prop;
        this.requestCampaign_prop = requestCampaign_prop;
    }

    public override bool Equals(object obj)
    {
        return obj is DataFomCoded data &&
               huw_protocol == data.huw_protocol &&
               huw_sim_geo == data.huw_sim_geo &&
               huw_bundle == data.huw_bundle &&
               huw_amidentificator == data.huw_amidentificator &&
               huw_afidentificator == data.huw_afidentificator &&
               huw_googleID == data.huw_googleID &&
               huw_subcodename == data.huw_subcodename &&
               bundle_prop == data.bundle_prop &&
               subcodename_prop == data.subcodename_prop &&
               domen_prop == data.domen_prop &&
               space_prop == data.space_prop &&
               requestCampaign_prop == data.requestCampaign_prop;
    }

    public override int GetHashCode()
    {
        int hashCode = 135796883;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(huw_protocol);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(huw_sim_geo);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(huw_bundle);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(huw_amidentificator);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(huw_afidentificator);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(huw_googleID);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(huw_subcodename);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(bundle_prop);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(subcodename_prop);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(domen_prop);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(space_prop);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(requestCampaign_prop);
        return hashCode;
    }
}
