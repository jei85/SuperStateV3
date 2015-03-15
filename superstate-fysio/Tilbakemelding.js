
function Tilbakemelding(){
    _this = this;
    _this.tilbakemeldinger;

    this.init = function(){

        var jsondataTilbakemeldinger = {
            "kunde":"Kåre Hansen",
            "tilbakemeldinger":[
                {
                    "id":1,
                    "rating":5,
                    "dato":"1.2.2015",
                    "kommentar":"Gikk bra i dag. Formen er bra."
                }
                ,
                {
                    "id":2,
                    "rating":3,
                    "dato":"5.2.2015",
                    "kommentar":"Litt vondt i kneet. Måtte hoppe over knebøy"
                }
                ,
                {
                    "id":2,
                    "rating":4,
                    "dato":"9.2.2015",
                    "kommentar":"Litt vondt i kneet, så tok kun halvparten av knebøy. Ellers bra"
                }
            ]
        };

        _this.tilbakemeldinger = jsondataTilbakemeldinger.tilbakemeldinger;
    };


    this.hentTilbakemeldinger = function(){
        return _this.tilbakemeldinger;
    };

}





