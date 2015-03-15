function Treningsprogram(){
    _this = this;
    _this.program;
    _this.startDato;
    _this.sluttDato;

    this.init = function(){

        var jsondataTreningsProgram = {
            startDato:"",
            sluttDato:"",
            "program":[
                {
                    "id":1,
                    "navn":"situps",
                    "sett":3,
                    "repitisjoner":15
                }
                ,
                {
                    "id":2,
                    "navn":"spensthopp",
                    "sett":3,
                    "repitisjoner":15
                }
                ,
                {
                    "id":3,
                    "navn":"knebøy",
                    "sett":3,
                    "repitisjoner":15
                }
            ]
        };

        _this.program = jsondataTreningsProgram.program;
    };

    this.reset = function(){
        init();
    };

    this.hentProgram = function(){
        return _this.program;
    };

}





