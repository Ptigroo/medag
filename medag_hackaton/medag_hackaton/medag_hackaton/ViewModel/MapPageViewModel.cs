using medag_hackaton.Models.Zone;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace medag_hackaton.ViewModel
{
    class MapPageViewModel : BaseViewModel
    {
        public double YMax { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double XMin { get; set; }
        public double XActu { get; set; }
        public double YActu { get; set; }
        public double PosXActu { get; set; }
        public double PosYActu { get; set; }
        public double MultY { get; set; }
        public double MultX { get; set; }
        private Rectangle rectOpponent;
        public Rectangle RectOpponent {
            get
            {
                return rectOpponent;
            }
            set
            {
                rectOpponent = value;
                OnPropertyChanged();
            }

        }
        private Rectangle rectUs;
        public Rectangle RectUs {
            get
            {
                return rectUs;
            }
            set
            {
                rectUs = value;
                OnPropertyChanged();
            }
        }
        public List<EtapeModel> Etapes { get; set; }
        public ParcourModel Parcour { get; set; }

        public MapPageViewModel(Interfaces.INavigation navigation) : base(navigation)
        {
            Etapes = new List<EtapeModel>();
            Etapes.Add(new EtapeModel
            {
                Id = 0,
                Nom = "Premiere etape",
                Position = new Position
                {
                    X = 3.942726,
                    Y = 50.453441
                },
                PhotoPath = "gareMons.jpg",
                Question = "De quelle couleur est la gare"

            });
            Parcour = new ParcourModel
            {
                Id = 1,
                Nom = "Ouest",
                Steps = Etapes
            };

            YMin = 50.444979;
            XMin = 3.922902;
            YMax = 50.462576;
            XMax = 3.972641;
            XActu = 3.964573;
            YActu = 50.452876;
            MultY = (1 / (YMax - YMin));
            MultX = (1 / (XMax - XMin));
            PosYActu = ((YMax - YActu) * MultY);
            PosXActu = ((XMax - XActu) * MultX);
            //field.Children.Add(demon, new Rectangle(PosYActu, PosXActu, 0.06, 0.06), AbsoluteLayoutFlags.All);

            Move();
        }
        public async void Move()
        {
            var locator = CrossGeolocator.Current;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(2));

            

            XActu = position.Longitude;
            YActu = position.Latitude;
            if (((XActu - Etapes[0].Position.X) < 0.005) && ((YActu - Etapes[0].Position.Y)<0.005))
            {

            }
            MultY = (1 / (YMax - YMin));
            MultX = (1 / (XMax - XMin));
            PosYActu = ((YMax - YActu) * MultY);
            PosXActu = ((XMax - XActu) * MultX);
            RectUs = new Rectangle(PosYActu, PosXActu, 0.06, 0.06);
            Move();
        }
    }
}
