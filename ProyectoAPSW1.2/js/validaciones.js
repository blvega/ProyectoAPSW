

function ListarCreditos(a) {
 
    var montoe = document.getElementById("montoe");
    var plazoe = document.getElementById("plazoe");
    var error = document.getElementById("error");


    error.innerHTML = "";
    montoe.innerHTML = "";
    plazoe.innerHTML = "";

    var xhttp = new XMLHttpRequest();

    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Creditos/Lista/" + a, true);
    xhttp.send();
  
    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            var credito = document.getElementById("cre");
            var select = document.querySelector("#cre");
            credito.innerHTML = "";
            
            JSON.parse(this.responseText).forEach(function (data, index) {
                
                const option = document.createElement("option");
                option.value = data.NombreCre;
                option.text = data.NombreCre;
              
                select.appendChild(option);

            });
        }


    };


};



function seleccionarCredito() {


    var listCredito = document.getElementById("cre").value;
    var mon = document.getElementById("moneda").value;
   
    var montoe = document.getElementById("montoe");
    var plazoe = document.getElementById("plazoe");
    var error = document.getElementById("error");


    error.innerHTML = "";
    montoe.innerHTML = "";
    plazoe.innerHTML = "";

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Creditos/" + listCredito + "/" + mon, true);
    xhttp.send();
    
    xhttp.onreadystatechange = function () {

       
            if (this.readyState == 4 && this.status == 200) {
                var response = JSON.parse(this.responseText);



                var camp = document.getElementById("tasa");
                var monto = document.getElementById("LimitesMonto");
                var plazo = document.getElementById("LimitesPlazo");



                camp.innerHTML = "";
                JSON.parse(this.responseText).forEach(function (data, index) {
                    if (document.getElementById("moneda").value == "Colones") {
                        camp.value = data.TasaColones;
                    } else {
                        camp.value = data.TasaDolares;
                    }


                 
                  

                    monto.innerHTML = "Monto mínimo " + data.MinimoMonto + " - Monto máximo " + data.MaximoMonto;
                    plazo.innerHTML = "Plazo mínimo " + data.MinimoPlazo + " - Plazo máximo " + data.MaximoPlazo;
                    //t.MinimoMonto,
                    //t.MaximoPlazo,
                    //t.MinimoPlazo,

                    window.localStorage.setItem('montom', data.MinimoMonto);
                    window.localStorage.setItem('montomax', data.MaximoMonto);
                    window.localStorage.setItem('plazom', data.MinimoPlazo);
                    window.localStorage.setItem('plazomax', data.MaximoPlazo);

                });
            }
       
       
    };
      
   
};

function MontoCuota() {


    var listCredito = document.getElementById("cre").value;

    var valoresAceptados = /^[0-9]+$/;

    const monto = document.getElementById('monto').value
    const tasa = document.getElementById('tasa').value
    const plazo = document.getElementById('plazo').value

    var cuotamensual = document.getElementById('montofinal')

    var montoe = document.getElementById("montoe");
    var plazoe = document.getElementById("plazoe");
    var error = document.getElementById("error");


    error.innerHTML = "";
    montoe.innerHTML = "";
    plazoe.innerHTML = "";

    const montominimo = localStorage.getItem('montom');
    const montomaximo = localStorage.getItem('montomax');
    const plazominimo = localStorage.getItem('plazom');
    const plazomaximo = localStorage.getItem('plazomax');

   
 

    if (parseFloat(document.getElementById('monto').value) > parseFloat(montomaximo) || parseFloat(document.getElementById('monto').value) < parseFloat(montominimo)) {
        montoe.innerHTML = "El monto no está dentro de los límites establecidos.";
    }
    else if (monto=="" || plazo=="" || tasa=="") {
       
        error.innerHTML = "Algunos campos no pueden estar vacíos.";
    }

    else if (!monto.match(valoresAceptados) || !plazo.match(valoresAceptados) ) {
        
        error.innerHTML = "Los campos no pueden contener letras. ";
    }

    else if (parseFloat(document.getElementById('plazo').value) > parseFloat(plazomaximo) || parseFloat(document.getElementById('plazo').value) < parseFloat(plazominimo)) {
        plazoe.innerHTML = "El plazo no está dentro de los límites establecidos.";
    }
    else if (document.getElementById("moneda").value == "") {
  
        error.innerHTML = "Debe seleccionar el tipo de moneda.";
    }
    else if (document.getElementById("cre").value == "Tipo de Crédito Personal") {
       
        error.innerHTML = "Debe seleccionar el tipo de crédito.";
    } else {

        var result = calcularCredito(tasa / 1200, plazo, -monto);

        function calcularCredito(ir, np, pv) {
            var pmt, pvif;


            if (ir === 0) return -(pv) / np;
            pvif = Math.pow(1 + ir, np);
            pmt = - ir * pv * (pvif) / (pvif - 1);

            var result = pmt;


            var CRC = new Intl.NumberFormat('en-CR', {
                style: 'currency',
                currency: 'CRC',
            });
            return CRC.format(result.toFixed(2))
        }

       
      
        cuotamensual.innerHTML = result.substring(4);

        SinRegistro()

        document.getElementById("solicitar").style.display = 'inline';


    }

} 


//function ShowSelected() {
//    /* Para obtener el valor */
//    var cod = document.getElementById("producto").value;
//    alert(cod);

//    /* Para obtener el texto */
//    var combo = document.getElementById("producto");
//    var selected = combo.options[combo.selectedIndex].text;
//    alert(selected);
//}

function SoliHref() {
    var url = '@Url.Action("Solicitud", "Index")';

    var nom = document.getElementById("cre").value;
    const monto = document.getElementById('monto').value
    const tasa = document.getElementById('tasa').value

    window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Solicitud/Solicitud/?monto=' + monto + '&tasa=' + tasa + '&nomcre=' + nom;
} 

function BuscarCliente() {
  

    var id = document.getElementById("identificacion").value;
    var error = document.getElementById("errorId");

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Clientes/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {
        error.innerHTML=""

        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {


                document.getElementById('nombre').value = data.Nombre;
                document.getElementById('apellido1').value = data.PrimerApellido;
                document.getElementById('apellido2').value = data.SegundoApellido;
                document.getElementById('telefono').value = data.Telefono;
                document.getElementById('correo').value = data.Correo;
                //var nueva = data.FechaNacimiento.replace("T"," ")
               //var nueva2= nueva.split(" ")[0].split("-").reverse().join("-");
                var srtDate = data.FechaNacimiento;
                var date = srtDate.substring(0, 10);
                document.getElementById('fecha').value = date;
                document.getElementById('salario').value = data.SalarioNeto;

            });
        } else if (this.readyState == 4 && this.status == 404){
            document.getElementById('nombre').value = "";
            document.getElementById('apellido1').value = "";
            document.getElementById('apellido2').value = "";
            document.getElementById('telefono').value = "";
            document.getElementById('correo').value = "";
            document.getElementById('fecha').value = "";
            document.getElementById('salario').value = "";

            Swal.fire(
                'Error',
                'Cliente con la identificación ingresda no registrada. Por favor digite la información necesaria para su debido registro'  ,
                'warning'
            )
          
        }


    };
} 



function RegistrarClic(string) {

    let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/clic";

    let xhr = new XMLHttpRequest();
    xhr.open("POST", url);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            console.log(xhr.responseText);
        }
    };


    let body = JSON.stringify({NombreCre:string})
    xhr.send(body);

}



//window.setInterval(function () {
//    l.innerHTML = n;
//    n++;
//}, 1000);


//function myEnterFunction() {
//    document.getElementById("demo2").innerHTML = x += 1;
//}
var contador;

function IniciarCont(string) {

 
    document.getElementById("number").style.color = "red";
    var l = document.getElementById("number");

    var segundos = 5;
     contador = setInterval(function () {
         if (segundos <= 0) {
             clearInterval(contador);
            l.innerHTML = "Finished";

            let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/posicionamiento";

            let xhr = new XMLHttpRequest();
            xhr.open("POST", url);

            xhr.setRequestHeader("Accept", "application/json");
            xhr.setRequestHeader("Content-Type", "application/json");

            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4) {
                    console.log(xhr.responseText);
                }
            };


            let body = JSON.stringify({ NombreCre: string })
            xhr.send(body);
        } else {
             l.innerHTML = segundos + " seconds remaining";
        }
         segundos -= 1;
    }, 1000);
}



function DetenerCont() {
/*    var n=0;*/
    document.getElementById("number").style.color = "black";

    var l = document.getElementById("number");

    clearInterval(contador);
   
}


function SinRegistro() {
   
    var l = document.getElementById("user").value;
    var nomCre = document.getElementById("cre").value;

    if (l == "") {
        //alert("Invitado")

        let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/sinRegistro";

        let xhr = new XMLHttpRequest();
        xhr.open("POST", url);

        xhr.setRequestHeader("Accept", "application/json");
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                console.log(xhr.responseText);
            }
        };


        let body = JSON.stringify({ NombreCre: nomCre })
        xhr.send(body);
    }
}

function SinFormailzar() {

    var us = document.getElementById("usuario2").value;
    var nomCre = document.getElementById("Nomcre").value;

    if (us != null) {
       
        
        let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/sinFormalizar";

        let xhr = new XMLHttpRequest();
        xhr.open("POST", url);

        xhr.setRequestHeader("Accept", "application/json");
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                console.log(xhr.responseText);
            }
        };


        let body = JSON.stringify({ NombreCre: nomCre , Identificacion: us})
        xhr.send(body);
    } 

    window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Home/Index';
}



function Clics() {
    const params = {
        fecha: document.getElementById("fechaclic").value,
        fecha1: document.getElementById("fechaclic1").value,
    }

    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/clics/grafico");

    xhttp.setRequestHeader("Accept", "application/json");
    xhttp.setRequestHeader("Content-Type", "application/json");

    xhttp.send(JSON.stringify(params));



    xhttp.onreadystatechange = function () {

        var cat = [];
        var clics = [];
        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {
                cat.push(data.NombreCre);
                clics.push(data.Count);

            });

            grafico1(cat, clics)


        } else if (this.readyState == 4 && this.status == 404) {
        };

    }
}

function Posicionamiento() {
    const params = {
        fecha: document.getElementById("fechaclic").value,
        fecha1: document.getElementById("fechaclic1").value,
    }

    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/posicionamiento/grafico");

    xhttp.setRequestHeader("Accept", "application/json");
    xhttp.setRequestHeader("Content-Type", "application/json");

    xhttp.send(JSON.stringify(params));



    xhttp.onreadystatechange = function () {

        var cat = [];
        var clics = [];
        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {
                cat.push(data.NombreCre);
                clics.push(data.Count);

            });

            grafico2(cat, clics)


        } else if (this.readyState == 4 && this.status == 404) {
        };

    }

}

function SinRegistro2() {
    const params = {
        fecha: document.getElementById("fechaclic").value,
        fecha1: document.getElementById("fechaclic1").value,
    }

    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/sinregistro/grafico");

    xhttp.setRequestHeader("Accept", "application/json");
    xhttp.setRequestHeader("Content-Type", "application/json");

    xhttp.send(JSON.stringify(params));



    xhttp.onreadystatechange = function () {

        var cat = [];
        var clics = [];
        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {
                cat.push(data.NombreCre);
                clics.push(data.Count);

            });

            grafico3(cat, clics)


        } else if (this.readyState == 4 && this.status == 404) {
        };

    }


}

function grafico1(category, val2) {

    Highcharts.chart('container', {
        chart: {
            type: 'column',
            backgroundColor: '#ffffff1e',


        },
        title: {
            text: 'Indicadores de a que créditos le están dando clic',
            style: {
                fontSize: '18px',
                color: '#FFFFFF'
            }
        },

        xAxis: {
            categories: category,
            labels: {
                style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }
            }

        },
        yAxis: {
            title: {
                text: 'Cantidad de clics', style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }

            },
            labels: {
                style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    enabled: true
                },
                enableMouseTracking: false
            }
        },
        series: [{
            name: 'Prestamos',
            data: val2,
            color: '#01579b'

        }]
    });
}

function grafico2(category, val2) {

    Highcharts.chart('container2', {
        chart: {
            type: 'column',
            backgroundColor: '#ffffff1e',


        },
        title: {
            text: 'Indicadores de Posicionamiento de puntero de mouse por más de 5 segundos sobre un crédito',
            style: {
                fontSize: '18px',
                color: '#FFFFFF'
            }
        },

        xAxis: {
            categories: category,
            labels: {
                style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }
            }

        },
        yAxis: {
            title: {
                text: 'Cantidad de veces por 5s ', style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }

            },
            labels: {
                style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    enabled: true
                },
                enableMouseTracking: false
            }
        },
        series: [{
            name: 'Prestamos',
            data: val2,
            color: '#01579b'

        }]
    });
}

function grafico3(category, val2) {

    Highcharts.chart('container3', {
        chart: {
            type: 'column',
            backgroundColor: '#ffffff1e',


        },
        title: {
            text: 'Cantidad de usuarios que no se autentican pero usan el módulo de pre cálculo de créditos y cuáles son los que eligen más',
            style: {
                fontSize: '18px',
                color: '#FFFFFF'
            }
        },

        xAxis: {
            categories: category,
            labels: {
                style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }
            }

        },
        yAxis: {
            title: {
                text: 'Cantidad de usuarios', style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }

            },
            labels: {
                style: {
                    fontSize: '18px',
                    color: '#FFFFFF'
                }
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    enabled: true
                },
                enableMouseTracking: false
            }
        },
        series: [{
            name: 'Prestamos',
            data: val2,
            color: '#01579b'

        }]
    });
}


function morris(category, val2) {
    new Morris.Line({
        // ID of the element in which to draw the chart.
        element: 'myfirstchart',
        // Chart data records -- each entry in this array corresponds to a point on
        // the chart.

        data: [
            { year: category, value: val2 },

        ],
        // The name of the data record attribute that contains x-values.
        xkey: 'year',
        // A list of names of data record attributes that contain y-values.
        ykeys: ['value'],
        // Labels for the ykeys -- will be displayed when you hover over the
        // chart.
        labels: ['Value']
    });

}


function BuscarSinFormalizar() {

    const params = {
        fecha: document.getElementById("fechaclic").value,
        fecha1: document.getElementById("fechaclic1").value,
    }

    var xhttp = new XMLHttpRequest();

    xhttp.open("POST", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/sinformalizar/lista");
    xhttp.setRequestHeader("Accept", "application/json");
    xhttp.setRequestHeader("Content-Type", "application/json");

    xhttp.send(JSON.stringify(params));

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);
            var tbody = document.getElementById("tabla1").querySelector("tbody");
            tbody.innerHTML = "";
            JSON.parse(this.responseText).forEach(function (data, index) {
                var srtDate = data.FechaIndicador;
                var date = srtDate.substring(0, 10);
             
                tbody.innerHTML += "<tr><td>" + data.Identificacion + "</td>" + "<td>" + data.Nombre + " " + data.PrimerApellido + " " + data.SegundoApellido + "<td>" + data.Correo + "</td>" + "</td>" + "<td>" + data.NombreCre + "</td>" + "<td>" + date + "</td>";

            });



        } else if (this.readyState == 4 && this.status == 404) {


        }
    };
}




function ModalAsigAnalista(string) {

     document.getElementById('idPrueba').value=string

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/solicitudes/" + string, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {
       

        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {

                var srtDate = data.Fecha;
                var date = srtDate.substring(0, 10);
               
                document.getElementById('sfecha').value = date;
                document.getElementById('smonto').value = data.Monto;
                document.getElementById('scredito').value = data.NombreCre;
                document.getElementById('sid').value = data.Identificacion;
                document.getElementById('sestado').value = data.Estado;
               
                listaAnalitas()
            });

            $(document).ready(function () {
                $('#modal1').modal('open');
            });
        } else if (this.readyState == 4 && this.status == 404) {
            
            
        }


    };
    


}

function listaAnalitas() {
    var xhttp = new XMLHttpRequest();



    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/analistas", true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            var analista = document.getElementById("analistas");
            var select = document.querySelector("#analistas");
            
            analista.innerHTML = "";
            JSON.parse(this.responseText).forEach(function (data, index) {

                const option = document.createElement("option");
                option.value = data.Nombre+ " "+data.PrimerApellido+" "+ data.SegundoApellido;
                option.text = data.Nombre + " " + data.PrimerApellido + " " + data.SegundoApellido;

                select.appendChild(option);

            });
        }


    };
}


function AsignarAnalista() {

    var analista = document.getElementById("analistas").value;

    var id = document.getElementById("sid").value;
    var fecha = document.getElementById("sfecha").value;


    var srtDate = fecha;
    var date = srtDate.substring(0, 10);

    var er = document.getElementById("error");

    var idsoli = document.getElementById('idPrueba').value

    let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/analistas/"+idsoli;

    let xhr = new XMLHttpRequest();
    xhr.open("PUT", url);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == "200") {
            console.log(xhr.responseText);

            window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Tramite';
        } else if (xhr.readyState == 4 && xhr.status == "409") {
            Swal.fire(
                'Error',
                'El analista solo puede tener como máximo 5 solicitudes pendientes',
                'error'
            )
          
        }
    };


    let body = JSON.stringify({ Responsable: analista, Identificacion: id, Fecha: date })
    xhr.send(body);
}




function ModalAsigAnalistaEstado(string) {

    document.getElementById('idPrueba').value = string

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Analista1/" + string, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {

               


                var srtDate = data.Fecha;
                var date = srtDate.substring(0, 10);
                document.getElementById('sfecha').value = date;
                document.getElementById('smonto').value = data.Monto;
                document.getElementById('scredito').value = data.NombreCre;
                document.getElementById('sid').value = data.Identificacion;
                document.getElementById('sende').value = data.Endeudamiento;
                document.getElementById('stasa').value = data.TasaInteres;
                document.getElementById('sresponsable').value = data.Responsable;

                
            });

            $(document).ready(function () {
                $('#modal2').modal('open');
            });
        } else if (this.readyState == 4 && this.status == 404) {


        }


    };



}

function AsignarEstado() {

    var estado = document.getElementById("sestado").value;
    var comentario = document.getElementById("scomentario").value;
    var responsable = document.getElementById("sresponsable").value;
    var id = document.getElementById("sid").value;

    var er = document.getElementById("error");

    var idsoli = document.getElementById('idPrueba').value

    let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/analista/Estado/" + idsoli;

    let xhr = new XMLHttpRequest();
    xhr.open("PUT", url);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == "200") {
            console.log(xhr.responseText);

            window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/SoliAnalista';
        } else if (xhr.readyState == 4 && xhr.status == "404"){
            Swal.fire(
                'Error',
                'Error al intentar cambiar el estado de la solicitud indicada.',
                'error'
            )
        }
    };


    let body = JSON.stringify({ Estado: estado, Comentario: comentario, Responsable: responsable, Identificacion: id})
    xhr.send(body);
}



function ModalEnvioCorreo(credito) {


   
    //const correo = document.getElementById('correo').value

    if (credito == "Capital de trabajo") {


        $(document).ready(function () {
            $('#modalCT').modal('open');
        });
    } else if (credito == "Maquinaria y equipo") {
        $(document).ready(function () {
            $('#modalME').modal('open');
        });
    }
    else if (credito == "Compra vehículo") {
        $(document).ready(function () {
            $('#modalCV').modal('open');
        });
    }
    else if (credito == "Compra vivienda") {
        $(document).ready(function () {
            $('#modalCVIV').modal('open');
        });
    }
    else if (credito == "Estudios") {
        $(document).ready(function () {
            $('#modalE').modal('open');
        });
    }
    else if (credito == "Mejora de instalaciones") {
        $(document).ready(function () {
            $('#modalMI').modal('open');
        });
    }
    else if (credito == "Salud") {
        $(document).ready(function () {
            $('#modalS').modal('open');
        });
    }
    else if (credito == "Unificacion") {
        $(document).ready(function () {
            $('#modalU').modal('open');
        });
    }
    else if (credito == "Vehiculo de trabajo") {
        $(document).ready(function () {
            $('#modalVT').modal('open');
        });
    }
    else {
        $(document).ready(function () {
            $('#modalV').modal('open');
        });
    }
}





function EnvioCorreo(nomCre) {
    

  
    const correo = document.getElementById('correo').value
  

    window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Principal/CapitalTrabajo/?nom=' + nomCre + '&correo=' + correo ;
} 




function RegistroUsuarios() {
    const params = {
        Identificacion: document.getElementById("idusuario").value,
        Nombre: document.getElementById("nomusuario").value,
        PrimerApellido: document.getElementById("p1usuario").value,
        SegundoApellido: document.getElementById("p2usuario").value,
        Telefono: document.getElementById("teleusuario").value,
        Correo: document.getElementById("corusuario").value,
        Password: document.getElementById("contusuario").value,
        IdRol: document.getElementById("rolusuario").value
    }

    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confUsuarios/post");

    xhttp.setRequestHeader("Accept", "application/json");
    xhttp.setRequestHeader("Content-Type", "application/json");

    xhttp.send(JSON.stringify(params));



    xhttp.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 201) {
            var response = JSON.parse(this.responseText);

            swal.fire({
                title: "Usuario creado",
                text: "Los datos se registraron correctamente",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfUsuarios';
            });
         


        } else if (this.readyState == 4 && this.status == 409) {
            Swal.fire(
                'Error',
                'Todos los datos solicitados son necesarios',
                'error'
            )
        };

    }


}

function MostrarNombreRoles(id) {



    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/MostrarRoles/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                    document.getElementById("rolusuario2").value = data.Nombre


            });

        } else if (this.readyState == 4 && this.status == 404) {


        }


    };
}

function MostrarNombreRoles2(id) {



    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/MostrarRoles/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                document.getElementById("rolusuario3").value = data.idRol


            });

        } else if (this.readyState == 4 && this.status == 404) {


        }


    };
}

function MasInformacion(id) {
   
    

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



               document.getElementById("idusuario2").value = data.Identificacion,
               document.getElementById("nomusuario2").value = data.Nombre,
               document.getElementById("p1usuario2").value = data.PrimerApellido,
               document.getElementById("p2usuario2").value = data.SegundoApellido ,
               document.getElementById("teleusuario2").value = data.Telefono ,
               document.getElementById("corusuario2").value = data.Correo,
               document.getElementById("contusuario2").value = data.Password,
               MostrarNombreRoles(data.idRol)


            });

            $(document).ready(function () {
                $('#modalMasInformacion').modal('open');
            });
        } else if (this.readyState == 4 && this.status == 404) {


        }


    };
}

function ModificarUsuarios() {
    const params = {
        Identificacion: document.getElementById("idusuario3").value,
        Nombre: document.getElementById("nomusuario3").value,
        PrimerApellido: document.getElementById("p1usuario3").value,
        SegundoApellido: document.getElementById("p2usuario3").value,
        Telefono: document.getElementById("teleusuario3").value,
        Correo: document.getElementById("corusuario3").value,
        Password: document.getElementById("contusuario3").value,
        IdRol: document.getElementById("rolusuario3").value
    }

    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confUsuarios/post");

    xhttp.setRequestHeader("Accept", "application/json");
    xhttp.setRequestHeader("Content-Type", "application/json");

    xhttp.send(JSON.stringify(params));



    xhttp.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 201) {
            var response = JSON.parse(this.responseText);

            swal.fire({
                title: "Usuario modificado",
                text: "Los datos se actualizaron correctamente",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfUsuarios';
            });

     



        } else if (this.readyState == 4 && this.status == 409) {
            Swal.fire(
                'Error',
                'Todos los datos solicitados son necesarios',
                'error'
            )
        };

    }


}

function ModalEditarUsuario(id) {

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                document.getElementById("idusuario3").value = data.Identificacion,
                    document.getElementById("nomusuario3").value = data.Nombre,
                    document.getElementById("p1usuario3").value = data.PrimerApellido,
                    document.getElementById("p2usuario3").value = data.SegundoApellido,
                    document.getElementById("teleusuario3").value = data.Telefono,
                    document.getElementById("corusuario3").value = data.Correo,
                    document.getElementById("contusuario3").value = data.Password
                MostrarNombreRoles2(data.idRol)
                 


            });
            $(document).ready(function () {
                $('#modalModificarUsuario').modal('open');
            });
          
        } else if (this.readyState == 4 && this.status == 404) {


        }


    };

   

}

function ModificarUsuario() {

    var iduser = document.getElementById("idusuario3").value;
    var nom =document.getElementById("nomusuario3").value;
    var p1 =document.getElementById("p1usuario3").value;
    var p2 =document.getElementById("p2usuario3").value;
    var te =document.getElementById("teleusuario3").value;
    var co =document.getElementById("corusuario3").value;
    var cont = document.getElementById("contusuario3").value;
    var rol = document.getElementById("rolusuario3").value 

    let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confUsuarios/put/" + iduser;

    let xhr = new XMLHttpRequest();
    xhr.open("PUT", url);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == "200") {
            console.log(xhr.responseText);
            swal.fire({
                title: "Usuario modificado",
                text: "Los datos se actualizaron correctamente",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfUsuarios';
            });
        } else if (xhr.readyState == 4 && xhr.status == "404") {
            Swal.fire(
                'Error',
                'El analista solo puede tener como máximo 5 solicitudes pendientes',
                'error'
            )

        }
     else if (xhr.readyState == 4 && xhr.status == "409") {
        Swal.fire(
            'Error',
            'Ningún dato puede estar vacío y deben tener el formato correcto ',
            'error'
        )

    }
    };


    let body = JSON.stringify({ Nombre: nom, PrimerApellido: p1, SegundoApellido: p2, Telefono: te, Correo: co, Password: cont, idRol: rol})
    xhr.send(body);
}


function BuscarUusarios() {
    var id2;
    var tbody = document.getElementById("tablaUsuarios").querySelector("tbody");
    tbody.innerHTML = "";
  
    var id = document.getElementById("valor").value;
    var opcion = document.getElementById("busqueda").value;
    //var nom = document.getElementById("busqueda").value;
    if (id != "") {
        if (opcion == 2) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.Identificacion + "</td>" + "<td>" + data.Nombre + "</td>" + "<td>" + data.PrimerApellido + "</td>" + "<td>" + data.SegundoApellido + "</td>"
                            + "<td>" + data.Telefono + "</td>" + "<td>" + data.Correo + "</td>" + "<td><a name='eli' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>more_horiz</a> <a name='eli2' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>edit</a></td></tr>";
                        id2 = data.Identificacion;
                    });

                    $("a[name=eli]").on("click", function () {
                   

                        MasInformacion(id2);
                       
                    });

                    $("a[name=eli2]").on("click", function () {
                        ModalEditarUsuario(id2);


                    });


                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe la identificación ingresada",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfUsuarios';
                    });
                }


            };
        } else if (opcion == 3) {

            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/nom/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.Identificacion + "</td>" + "<td>" + data.Nombre + "</td>" + "<td>" + data.PrimerApellido + "</td>" + "<td>" + data.SegundoApellido + "</td>"
                            + "<td>" + data.Telefono + "</td>" + "<td>" + data.Correo + "</td>" + " <td><a name='eli' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>more_horiz</a> <a name='eli2' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>edit</a></td ></tr>";

                        id2 = data.Identificacion;
                    });

                    $("a[name=eli]").on("click", function () {
                   

                        MasInformacion(id2);

                    });

                    $("a[name=eli2]").on("click", function () {
                        ModalEditarUsuario(id2);


                    });
                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe el nombre ingresado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfUsuarios';
                    });
                }


            };
        } else if (opcion = "1") {
            swal.fire({
                title: "Error",
                text: "Debe indicar la herramienta de busqueda",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfUsuarios';
            });
           
        }

       
    } else {
        swal.fire({
            title: "Error",
            text: "Debe indicar el parametro a buscar",
            type: 'error'
        }).then(function () {
            window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfUsuarios';
        });
    }
}

function ModalCambiarContraseña() {
    $(document).ready(function () {
        $('#modalContra').modal('open');
    });
}


function EnviarContra() {

    var id = document.getElementById("idcontra").value;
    var cor = document.getElementById("correo").value;




 

       let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confUsuarios/enviarContra/" + id;

        let xhr = new XMLHttpRequest();
        xhr.open("POST", url);

        xhr.setRequestHeader("Accept", "application/json");
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == "200") {
                console.log(xhr.responseText);
                Swal.fire(
                    'Información enviada',
                    'Se envió al correo ingresado la información solicitada',
                    'success'
                )

        
            } else if (xhr.readyState == 4 && xhr.status == "404") {
                Swal.fire(
                    'Error',
                    'La información ingresada no coincide con ningún registro',
                    'error'
                )

            }
     else if (xhr.readyState == 4 && xhr.status == "409") {
        Swal.fire(
            'Error',
            'Toda la información solicitada es necesaria',
            'error'
        )

    }
         
        };


    let body = JSON.stringify({ Identificacion: id, Correo: cor })
        xhr.send(body);



   
    

}

function EnviarContra2() {

    var id = document.getElementById("idcontra").value;
    var cor = document.getElementById("correo").value;






    let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confUsuarios/enviarContra2/" + id;

    let xhr = new XMLHttpRequest();
    xhr.open("POST", url);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == "200") {
            console.log(xhr.responseText);
            Swal.fire(
                'Información enviada',
                'Se envió al correo ingresado la información solicitada',
                'success'
            )


        } else if (xhr.readyState == 4 && xhr.status == "404") {
            Swal.fire(
                'Error',
                'La información ingresada no coincide con ningún registro',
                'error'
            )

        }
        else if (xhr.readyState == 4 && xhr.status == "409") {
            Swal.fire(
                'Error',
                'Toda la información solicitada es necesaria',
                'error'
            )

        }

    };


    let body = JSON.stringify({ Identificacion: id, Correo: cor })
    xhr.send(body);






}
//Clientes
function MostrarNombreRoles3(id) {



    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/MostrarRoles/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                document.getElementById("rolcli2").value = data.idRol


            });

        } else if (this.readyState == 4 && this.status == 404) {


        }


    };
}

function MostrarNombreRoles4(id) {



    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/MostrarRoles/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                document.getElementById("rolcli3").value = data.idRol


            });

        } else if (this.readyState == 4 && this.status == 404) {


        }


    };
}


function MasInformacion2(id) {



    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfClientes/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                document.getElementById("idcli2").value = data.Identificacion,
                    document.getElementById("nomcli2").value = data.Nombre,
                    document.getElementById("p1cli2").value = data.PrimerApellido,
                    document.getElementById("p2cli2").value = data.SegundoApellido,
                    document.getElementById("telecli2").value = data.Telefono,
                    document.getElementById("corcli2").value = data.Correo,
                    document.getElementById("fechacli2").value = data.FechaNacimiento,
                    document.getElementById("salariocli2").value = data.SalarioNeto,
                    document.getElementById("endeucli2").value = data.Endeudamiento,
                    document.getElementById("contcli2").value = data.Password
                    var srtDate = data.FechaNacimiento;
                var date = srtDate.substring(0, 10);
                document.getElementById("fechacli2").value = date

                    MostrarNombreRoles3(data.idRol)


            });

            $(document).ready(function () {
                $('#modalMasInformacion2').modal('open');
            });
        } else if (this.readyState == 4 && this.status == 404) {


        }


    };
}

function RegistroClientes() {
    const params = {
        Identificacion: document.getElementById("idcli").value,
        Nombre: document.getElementById("nomcli").value,
        PrimerApellido: document.getElementById("p1cli").value,
        SegundoApellido: document.getElementById("p2cli").value,
        Telefono: document.getElementById("telecli").value,
        Correo: document.getElementById("corcli").value,
        SalarioNeto: document.getElementById("salariocli").value,
        Endeudamiento: document.getElementById("endecli").value,
        Password: document.getElementById("contcli").value,
        IdRol: document.getElementById("rocli").value,
        FechaNacimiento: document.getElementById("fechacli").value
    }

    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confClientes/post");

    xhttp.setRequestHeader("Accept", "application/json");
    xhttp.setRequestHeader("Content-Type", "application/json");

    xhttp.send(JSON.stringify(params));



    xhttp.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 201) {
            var response = JSON.parse(this.responseText);

            swal.fire({
                title: "Cliente agregado",
                text: "Se registró la información correctamente",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfClientes';
            });


        } else if (this.readyState == 4 && this.status == 409) {
            Swal.fire(
                'Error',
                'Todos los datos solicitados son necesarios',
                'error'
            )
        };

    }


}



function ModalEditarCliente(id) {

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfClientes/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                document.getElementById("idcli3").value = data.Identificacion,
                    document.getElementById("nomcli3").value = data.Nombre,
                    document.getElementById("p1cli3").value = data.PrimerApellido,
                    document.getElementById("p2cli3").value = data.SegundoApellido,
                    document.getElementById("telecli3").value = data.Telefono,
                    document.getElementById("corcli3").value = data.Correo,
                    document.getElementById("salariocli3").value = data.SalarioNeto,
                    document.getElementById("endeudamientocli3").value = data.Endeudamiento,
                    document.getElementById("contcli3").value = data.Password
                var srtDate = data.FechaNacimiento;
                var date = srtDate.substring(0, 10);
                document.getElementById("fechacli3").value = date
                MostrarNombreRoles4(data.idRol)



            });
            $(document).ready(function () {
                $('#modalModificarCliente').modal('open');
            });

        } else if (this.readyState == 4 && this.status == 404) {


        }


    };



}

function ModificarClientesConf() {

    var id4 = document.getElementById("idcli3").value ;
    var nom = document.getElementById("nomcli3").value ;
    var p1 = document.getElementById("p1cli3").value ;
    var p2 = document.getElementById("p2cli3").value ;
    var tel = document.getElementById("telecli3").value ;
    var correo = document.getElementById("corcli3").value ;
    var salario = document.getElementById("salariocli3").value ;
    var endeu = document.getElementById("endeudamientocli3").value ;
    var contra = document.getElementById("contcli3").value;
    var rol = document.getElementById("rolcli3").value;

    var fecha = document.getElementById("fechacli3").value;

    let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confClientes/put/" + id4;

    let xhr = new XMLHttpRequest();
    xhr.open("PUT", url);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == "200") {
            console.log(xhr.responseText);
            swal.fire({
                title: "Cliente modificado",
                text: "Los datos se actualizaron correctamente",
                type: 'success'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfClientes';
            });
        } else if (xhr.readyState == 4 && xhr.status == "404") {
            Swal.fire(
                'Error',
                'Cliente no registrado',
                'error'
            )

        }
        else if (xhr.readyState == 4 && xhr.status == "409") {
            Swal.fire(
                'Error',
                'Ningún dato puede estar vacío y deben tener el formato correcto ',
                'error'
            )

        }
    };


    let body = JSON.stringify({Identificacion:id4, Nombre: nom, PrimerApellido: p1,FechaNacimiento:fecha, SegundoApellido: p2, Telefono: tel, Correo: correo, Password: contra, SalarioNeto: salario, Endeudamiento: endeu, idRol: rol })
    xhr.send(body);
}

function BuscarClientes() {

    var tbody = document.getElementById("tablaClientes").querySelector("tbody");
    tbody.innerHTML = "";
    var id2;

    var id = document.getElementById("valor").value;
    var opcion = document.getElementById("busqueda").value;
    //var nom = document.getElementById("busqueda").value;
    if (id != "") {
        if (opcion == 2) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfClientes/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.Identificacion + "</td>" + "<td>" + data.Nombre + "</td>" + "<td>" + data.PrimerApellido + "</td>" + "<td>" + data.SegundoApellido + "</td>"
                            + "<td>" + data.Telefono + "</td>" + "<td>" + data.Correo + "</td>" + "<td><a name='clientes1' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>more_horiz</a> <a name='clientes2' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>edit</a></td></tr>";

                        id2=data.Identificacion
                    });

                    $("a[name=clientes1]").on("click", function () {


                        MasInformacion2(id2);

                    });

                    $("a[name=clientes2]").on("click", function () {
                        ModalEditarCliente(id2);


                    });

                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe la identificación ingresada",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfClientes';
                    });
                }


            };
        } else if (opcion==3) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfClientes/nom/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.Identificacion + "</td>" + "<td>" + data.Nombre + "</td>" + "<td>" + data.PrimerApellido + "</td>" + "<td>" + data.SegundoApellido + "</td>"
                            + "<td>" + data.Telefono + "</td>" + "<td>" + data.Correo + "</td>" + "<td><a name='clientes3' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>more_horiz</a> <a name='clientes4' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>edit</a></td></tr>";
                        id2 = data.Identificacion
                    });
                    $("a[name=clientes3]").on("click", function () {


                        MasInformacion2(id2);

                    });

                    $("a[name=clientes4]").on("click", function () {
                        ModalEditarCliente(id2);


                    });

                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe el nombre ingresado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfClientes';
                    });
                }


            };

        } else if (opcion = "1") {
            swal.fire({
                title: "Error",
                text: "Debe indicar la herramienta de busqueda",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfClientes';
            });

        }


    } else {
        swal.fire({
            title: "Error",
            text: "Debe indicar el parametro a buscar",
            type: 'error'
        }).then(function () {
            window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfClientes';
        });
    }
}


//creditos
function RegistroCreditos() {
    const params = {
 
        NombreCre: document.getElementById("nomcre").value,
        TasaColones: document.getElementById("tasacolones").value,
        TasaDolares: document.getElementById("tasadolares").value,
        MinimoPlazo: document.getElementById("plazomin").value,
        MaximoPlazo: document.getElementById("plazomax").value,
        MinimoMonto: document.getElementById("montomin").value,
        MaximoMonto: document.getElementById("montomax").value,
        Categoria:"Sin categoria"
 
    }

    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confCreditos/post");

    xhttp.setRequestHeader("Accept", "application/json");
    xhttp.setRequestHeader("Content-Type", "application/json");

    xhttp.send(JSON.stringify(params));



    xhttp.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 201) {
            var response = JSON.parse(this.responseText);

            swal.fire({
                title: "Crédito agregado",
                text: "Los datos se registraron correctamente",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfCreditos';
            });



        } else if (this.readyState == 4 && this.status == 409) {
            Swal.fire(
                'Error',
                'Todos los datos solicitados son necesarios',
                'error'
            )
        };

    }


}

function ModificarCreditosConf() {

    var nom = document.getElementById("nomcre2").value;
    var colones = document.getElementById("tasacolones2").value;
    var dolares =  document.getElementById("tasadolares2").value;
    var plazom = document.getElementById("plazomin2").value;
    var plazoM =  document.getElementById("plazomax2").value;
    var montom =  document.getElementById("montomin2").value;
    var montoM = document.getElementById("montomax2").value;
    var categoria =  "Sin categoria";

    let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confCreditos/put/" + nom;

    let xhr = new XMLHttpRequest();
    xhr.open("PUT", url);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == "200") {
            console.log(xhr.responseText);
            swal.fire({
                title: "Crédito modificado",
                text: "Los datos se actualizaron correctamente",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfCreditos';
            });
        } else if (xhr.readyState == 4 && xhr.status == "404") {
            Swal.fire(
                'Error',
                'Crédito no registrado',
                'error'
            )

        }
        else if (xhr.readyState == 4 && xhr.status == "409") {
            Swal.fire(
                'Error',
                'Ningún dato puede estar vacío y deben tener el formato correcto ',
                'error'
            )

        }
    };


    let body = JSON.stringify({ NombreCre: nom, TasaColones: colones, TasaDolares: dolares, MaximoMonto: montoM, MinimoMonto: montom, MaximoPlazo: plazoM, MinimoPlazo: plazom ,Categoria:categoria})
    xhr.send(body);
}

function ModalEditarCreditoConf(id) {

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfCreditos/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {

               
              
             
                document.getElementById("tasacolones2").value = data.TasaColones,
                   
                  document.getElementById("nomcre2").value = data.NombreCre,
                    document.getElementById("tasadolares2").value = data.TasaDolares,
                    document.getElementById("plazomin2").value = data.MinimoPlazo,
                    document.getElementById("plazomax2").value = data.MaximoPlazo,
                    document.getElementById("montomin2").value = data.MinimoMonto,
                    document.getElementById("montomax2").value = data.MaximoMonto



            });
            $(document).ready(function () {
                $('#modalModificarCredito2').modal('open');
            });

        } else if (this.readyState == 4 && this.status == 404) {


        }


    };



}

function BuscarCredictosConf() {
   var id2;
    var tbody = document.getElementById("tablaCreditos").querySelector("tbody");
    tbody.innerHTML = "";

    var id = document.getElementById("valor").value;
   
    //var nom = document.getElementById("busqueda").value;
    if (id != "") {
        var xhttp = new XMLHttpRequest();
        xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfCreditos/" + id, true);
        xhttp.send();

        xhttp.onreadystatechange = function () {


            if (this.readyState == 4 && this.status == 200) {
                var response = JSON.parse(this.responseText);

                JSON.parse(this.responseText).forEach(function (data, index) {

                    tbody.innerHTML += "<tr><td>" + data.NombreCre + "</td>" + "<td>" + data.TasaColones + "</td>" + "<td>" + data.TasaDolares + "</td>" + "<td>" + data.MinimoPlazo + "</td>"
                        + "<td>" + data.MaximoPlazo + "</td>" + "<td>" + data.MinimoMonto + "</td>" + "<td>" + data.MaximoMonto + "</td>" + "<td><a name='creditos' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>more_horiz</a></td></tr>";
                    id2 = data.NombreCre;
                });
                $("a[name=creditos]").on("click", function () {
                    ModalEditarCreditoConf(id2);
                });

            } else if (this.readyState == 4 && this.status == 404) {
                swal.fire({
                    title: "Error",
                    text: "No existe el nombre ingresado",
                    type: 'error'
                }).then(function () {
                    window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfCreditos';
                });
            }


        };

    } else {
        swal.fire({
            title: "Error",
            text: "Debe indicar el parametro a buscar",
            type: 'error'
        }).then(function () {
            window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/ConfCreditos';
        });
    }
}




//administracion cliente personal

function ModificarClientesConf2() {

    var id4 = document.getElementById("idcli3").value;
    var nom = document.getElementById("nomcli3").value;
    var p1 = document.getElementById("p1cli3").value;
    var p2 = document.getElementById("p2cli3").value;
    var tel = document.getElementById("telecli3").value;
    var correo = document.getElementById("corcli3").value;
    var salario = document.getElementById("salariocli3").value;
    var endeu = document.getElementById("endeudamientocli3").value;
    var contra = document.getElementById("contcli3").value;
   

    var fecha = document.getElementById("fechacli3").value;

    let url = "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/confClientes/put/" + id4;

    let xhr = new XMLHttpRequest();
    xhr.open("PUT", url);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == "200") {
            console.log(xhr.responseText);
            swal.fire({
                title: "Cliente modificado",
                text: "Los datos se actualizaron correctamente",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Principal/AdministracionCliente';
            });
        } else if (xhr.readyState == 4 && xhr.status == "404") {
            Swal.fire(
                'Error',
                'Cliente no registrado',
                'error'
            )

        }
        else if (xhr.readyState == 4 && xhr.status == "409") {
            Swal.fire(
                'Error',
                'Ningún dato puede estar vacío y deben tener el formato correcto ',
                'error'
            )

        }
    };


    let body = JSON.stringify({ Identificacion: id4, Nombre: nom, PrimerApellido: p1, FechaNacimiento: fecha, SegundoApellido: p2, Telefono: tel, Correo: correo, Password: contra, SalarioNeto: salario, Endeudamiento: endeu, idRol: 3 })
    xhr.send(body);
}


function ModalEditarCliente2(id) {

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfClientes/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                document.getElementById("idcli3").value = data.Identificacion,
                    document.getElementById("nomcli3").value = data.Nombre,
                    document.getElementById("p1cli3").value = data.PrimerApellido,
                    document.getElementById("p2cli3").value = data.SegundoApellido,
                    document.getElementById("telecli3").value = data.Telefono,
                    document.getElementById("corcli3").value = data.Correo,
                    document.getElementById("salariocli3").value = data.SalarioNeto,
                    document.getElementById("endeudamientocli3").value = data.Endeudamiento,
                    document.getElementById("contcli3").value = data.Password
                var srtDate = data.FechaNacimiento;
                var date = srtDate.substring(0, 10);
                document.getElementById("fechacli3").value = date
           



            });
            $(document).ready(function () {
                $('#modalModificarCliente2').modal('open');
            });

        } else if (this.readyState == 4 && this.status == 404) {


        }


    };



}

function MasInformacionClienteAdmi2(id) {



    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfClientes/" + id, true);
    xhttp.send();

    xhttp.onreadystatechange = function () {


        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            JSON.parse(this.responseText).forEach(function (data, index) {



                document.getElementById("idcli2").value = data.Identificacion,
                    document.getElementById("nomcli2").value = data.Nombre,
                    document.getElementById("p1cli2").value = data.PrimerApellido,
                    document.getElementById("p2cli2").value = data.SegundoApellido,
                    document.getElementById("telecli2").value = data.Telefono,
                    document.getElementById("corcli2").value = data.Correo,
                    document.getElementById("fechacli2").value = data.FechaNacimiento,
                    document.getElementById("salariocli2").value = data.SalarioNeto,
                    document.getElementById("endeucli2").value = data.Endeudamiento,
                    document.getElementById("contcli2").value = data.Password
                var srtDate = data.FechaNacimiento;
                var date = srtDate.substring(0, 10);
                document.getElementById("fechacli2").value = date

           


            });

            $(document).ready(function () {
                $('#modalMasInformacionCliAdmin2').modal('open');
            });
        } else if (this.readyState == 4 && this.status == 404) {


        }


    };
}


function BuscarSolicitudesAprobadas() {

    var tbody = document.getElementById("tablaAprobadas").querySelector("tbody");
    tbody.innerHTML = "";
  

    var id = document.getElementById("valor").value;
    var opcion = document.getElementById("busqueda").value;
    //var nom = document.getElementById("busqueda").value;
    if (id != "") {
        if (opcion == 3) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Aprobadas/Nombre/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                            + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>"+ "<td>" + data.Responsable + "</td>" + "<td>" + data.Comentario + "</td></tr>";

                     
                    });


                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe el tipo de crédito ingresado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Aprobadas';
                    });
                }


            };
        } else if (opcion == 2) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Aprobadas/Identificacion/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                            + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>" + "<td>" + data.Responsable + "</td>" + "<td>" + data.Comentario + "</td></tr>";

                    });

                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe la identificación del cliente ingresado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Aprobadas';
                    });
                }


            };

        
    } else if (opcion == 1) {
        var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Aprobadas/idSoli/" + id, true);
        xhttp.send();

        xhttp.onreadystatechange = function () {


            if (this.readyState == 4 && this.status == 200) {
                var response = JSON.parse(this.responseText);

                JSON.parse(this.responseText).forEach(function (data, index) {

                    tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                        + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>" + "<td>" + data.Responsable + "</td>" + "<td>" + data.Comentario + "</td></tr>";

                });

            } else if (this.readyState == 4 && this.status == 404) {
                swal.fire({
                    title: "Error",
                    text: "No existe el id de solicitud indicado",
                    type: 'error'
                }).then(function () {
                    window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Aprobadas';
                });
            }


        };

    }else if (opcion = "1") {
            swal.fire({
                title: "Error",
                text: "Debe indicar la herramienta de busqueda",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Aprobadas';
            });

        }


    } else {
        swal.fire({
            title: "Error",
            text: "Debe indicar el parametro a buscar",
            type: 'error'
        }).then(function () {
            window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Aprobadas';
        });
    }
}


function BuscarSolicitudesDenegadas2() {

    var tbody = document.getElementById("tablaDenegadas").querySelector("tbody");
    tbody.innerHTML = "";


    var id = document.getElementById("valor").value;
    var opcion = document.getElementById("busqueda").value;
    //var nom = document.getElementById("busqueda").value;
    if (id != "") {
        if (opcion == 3) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Denegado/Nombre/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                            + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>" + "<td>" + data.Responsable + "</td>" + "<td>" + data.Comentario + "</td></tr>";


                    });


                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe el tipo de crédito ingresado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Denegadas';
                    });
                }


            };
        } else if (opcion == 2) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Denegado/Identificacion/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                            + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>" + "<td>" + data.Responsable + "</td>" + "<td>" + data.Comentario + "</td></tr>";

                    });

                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe la identificación del cliente ingresado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Denegadas';
                    });
                }


            };


        } else if (opcion == 1) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Denegado/idSoli/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                            + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>" + "<td>" + data.Responsable + "</td>" + "<td>" + data.Comentario + "</td></tr>";

                    });

                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe el id de solicitud indicado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Denegadas';
                    });
                }


            };

        } else if (opcion = "1") {
            swal.fire({
                title: "Error",
                text: "Debe indicar la herramienta de busqueda",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Denegadas';
            });

        }


    } else {
        swal.fire({
            title: "Error",
            text: "Debe indicar el parametro a buscar",
            type: 'error'
        }).then(function () {
            window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Denegadas';
        });
    }
}


function BuscarSolicitudesTramite2() {

    var tbody = document.getElementById("tablaTramite").querySelector("tbody");
    tbody.innerHTML = "";

    var ids;
    var id = document.getElementById("valor").value;
    var opcion = document.getElementById("busqueda").value;
    //var nom = document.getElementById("busqueda").value;
    if (id != "") {
        if (opcion == 3) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Pendiente1/Nombre/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                            + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>" + "<td>" + data.Responsable + "</td>" + "<td><a name='tramite1' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>edit</a></td></tr>";
                        ids = data.idSolicitud;

                    });

                    $("a[name=tramite1]").on("click", function () {


                        ModalAsigAnalista(ids);

                    });
                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe el tipo de crédito ingresado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Tramite';
                    });
                }


            };
        } else if (opcion == 2) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Pendiente3/Identificacion/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {

                        tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                            + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>" + "<td>" + data.Responsable + "</td>" + "<td><a name='tramite2' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>edit</a></td></tr>";
                        ids = data.idSolicitud;
                    });

                    $("a[name=tramite2]").on("click", function () {


                        ModalAsigAnalista(ids);

                    });
                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe la identificación del cliente ingresado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Tramite';
                    });
                }


            };


        } else if (opcion == 1) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Pendiente4/idSoli/" + id, true);
            xhttp.send();

            xhttp.onreadystatechange = function () {


                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);

                    JSON.parse(this.responseText).forEach(function (data, index) {
                        tbody.innerHTML += "<tr><td>" + data.idSolicitud + "</td>" + "<td>" + data.Fecha + "</td>" + "<td>" + data.Identificacion + "</td>" + "<td>" + data.Monto + "</td>"
                            + "<td>" + data.NombreCre + "</td>" + "<td>" + data.Estado + "</td>" + "<td>" + data.Responsable + "</td>" + "<td><a name='tramite3' i class='material-icons modal-trigger' style='vertical-align: middle; color: white;'>edit</a></td></tr>";
                        ids = data.idSolicitud;
                    });


                    $("a[name=tramite3]").on("click", function () {


                        ModalAsigAnalista(ids);

                    });

                } else if (this.readyState == 4 && this.status == 404) {
                    swal.fire({
                        title: "Error",
                        text: "No existe el id de solicitud indicado",
                        type: 'error'
                    }).then(function () {
                        window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Tramite';
                    });
                }


            };

        } else if (opcion = "1") {
            swal.fire({
                title: "Error",
                text: "Debe indicar la herramienta de busqueda",
                type: 'error'
            }).then(function () {
                window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Tramite';
            });

        }


    } else {
        swal.fire({
            title: "Error",
            text: "Debe indicar el parametro a buscar",
            type: 'error'
        }).then(function () {
            window.location.href = 'https://tiusr7pl.cuc-carrera-ti.ac.cr/Tramitador/Tramite';
        });
    }
}