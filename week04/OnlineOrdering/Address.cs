public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        // The expected user input is USA but the user may enter usa, Usa, uSA, etc.
        // The ToUpper() method converts the string to all uppercase letters.
        // The Trim() method removes any leading or trailing whitespace from the string.
        return _country.ToUpper().Trim() == "USA";

    }

    public string AddressDisplay()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}