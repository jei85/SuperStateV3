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
                ,
                {
                    "id":4,
                    "navn":"pushups"
                }
                ,
                {
                    "id":5,
                    "navn":"markløft"
                }
                ,
                {
                    "id":6,
                    "navn":"benkpress"
                }
                ,
                {
                    "id":7,
                    "navn":"militærpress"
                }
                ,
                {
                    "id":8,
                    "navn":"skulderpress"
                }
                ,
                {
                    "id":9,
                    "navn":"skulderhev"
                }
                ,
                {
                    "id":10,
                    "navn":"utfall"
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

    this.setValgt = function(valgt){
        _this.valgt = valgt;
        console.log("ny valgt: " + _this.valgt);
    };

    this.hentValgt = function(){
        return _this.valgt;
    };

    this.filtrer = function(c){
        console.log("filtrer funksjon: filtrer på c: " + c);

        //TODO: må endres til å takle flere bokstaver
        _this.alleAktiviteter = _.filter(_this.alleAktiviteter, function(a){ return a.navn.charAt(0).toLowerCase() == c.toLowerCase()});

        ///TODO: hva skal skje dersom valgt fjernes fra lista? (har et tall)
        ///tallet beholdes og settes til aktivitetslistas lengde minus 1 dersom valgt er høyere!!


        if(_this.hentValgt() >= _this.alleAktiviteter.length){
            _this.setValgt(_this.alleAktiviteter.length - 1);
        }
    };

}





