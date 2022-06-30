using MarsRover.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.UnitTest.Fixture
{
    public class MarsRoverImageFixture
    {
        public static List<Image> GetTestImages() =>
            new List<Image>()
            {
                new Image
                {
                    Date = "2022-01-01",
                    ImageUrl = new List<ImageUrl>
                    {
                        new ImageUrl
                        {
                            Url = "https://mars.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/03513/opgs/edr/ncam/NLB_709366153EDR_F0953152NCAM00322M_.JPG"
                        },
                        new ImageUrl
                        {
                            Url = "https://mars.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/03513/opgs/edr/ncam/NLB_709365884EDR_F0953152NCAM00323M_.JPG"
                        },
                        new ImageUrl
                        {
                            Url = "https://mars.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/03513/opgs/edr/ncam/NLB_709355700EDR_F0953152NCAM00560M_.JPG"
                        }
                    }
                },
                new Image
                {
                    Date = "2022-01-02",
                    ImageUrl = new List<ImageUrl>
                    {
                        new ImageUrl
                        {
                            Url = "https://mars.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/03512/opgs/edr/ncam/NLB_709280122EDR_F0953152NCAM00309M_.JPG"
                        },
                        new ImageUrl
                        {
                            Url = "https://mars.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/03512/opgs/edr/ncam/NLB_709272802EDR_F0953152NCAM00322M_.JPG"
                        }
                    }
                },
                new Image
                {
                    Date = "2022-01-03",
                    ImageUrl = new List<ImageUrl>
                    {
                        new ImageUrl
                        {
                            Url = "https://mars.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/03511/opgs/edr/ncam/NLB_709185914EDR_F0953152NCAM00200M_.JPG"
                        }
                    }
                },
                new Image
                {
                    Date = "2022-01-04",
                    ImageUrl = new List<ImageUrl>
                    {

                    }
                }
            };
    }
}
