using Xunit;
using Refugee.Models;
using Refugee.Services;

namespace RefugeeTest;

public class UnitTest1
{
    private DriverModelValidation _driverModelValidation = new DriverModelValidation();

    [Fact]
    public void TestSnakeCaseMethod()
    {
        string keyOne = "FirstName";
        string keyTwo = "abcd";
        string keyThree = "aBcd";
        
        string actualKeyOne = _driverModelValidation.RenameFieldToColumnName(keyOne);
        string actualKeyTwo = _driverModelValidation.RenameFieldToColumnName(keyTwo);
        string actualKeyThree = _driverModelValidation.RenameFieldToColumnName(keyThree);

        Assert.Equal("first_name", actualKeyOne);
        Assert.Equal("abcd",actualKeyTwo);
        Assert.Equal("a_bcd", actualKeyThree);
    }


}