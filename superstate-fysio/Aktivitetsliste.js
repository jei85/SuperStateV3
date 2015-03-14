function Aktivitetsliste(){
    _this = this;
    _this.alleAktiviteter;
    _this.valgt = 0;

    this.init = function(){

        var jsondataAlleAktiviteter = {
            "aktiviter":[
                {
                    "id":1,
                    "navn":"situps"
                }
                ,
                {
                    "id":2,
                    "navn":"spensthopp"
                }
                ,
                {
                    "id":3,
                    "navn":"knebøy"
                }
            ]
        };

        _this.alleAktiviteter = jsondataAlleAktiviteter.aktiviter;
    };

    this.reset = function(){
        init();
    };

    this.hentAlle = function(){
        return _this.alleAktiviteter;
    };

    this.filtrer = function(c){
        console.log("filtrer på c: " + c);

        _this.alleAktiviteter = _.filtrer(_this.alleAktiviteter, function(a){

            //TODO: må endres til å takle flere bokstaver
            return a.navn.charAt(0).toLowerCase() == c.toLowerCase()
        });
    }

}





