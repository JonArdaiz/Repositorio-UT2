// Los datos de la caja que se mantienen mientras el programa está abierto
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

int ventasRealizadas = 0;
decimal recaudacion = 0;
decimal ventaMasCara = 0;
string clienteVentaMasCara = "";
int opcionPrincipal;

// Stock inicial de los videojuegos disponibles
int stockZelda = 8;
int stockFifa = 4;
int stockPokemon = 5;
int stockAssasinsCreed = 2;

//Menú principal

do
{
    Console.WriteLine("======================================");
    Console.WriteLine("                    GAMEHUB   ");
    Console.WriteLine("======================================");
    Console.WriteLine("1. Registrar una venta");
    Console.WriteLine("2. Consultar caja del día y stock");
    Console.WriteLine("0. Salir");
    Console.WriteLine("Selecciona una opción: ");
    opcionPrincipal = int.Parse(Console.ReadLine()!);

    if (opcionPrincipal == 1)
    {
        //Fase 1. Datos del cliente
        Console.WriteLine();
        Console.WriteLine("--- NUEVA VENTA ---");

        string nombreCliente;

        do
        {
            Console.WriteLine("Nombre del cliente: ");
            nombreCliente = Console.ReadLine() ?? "";

            if (nombreCliente.Trim() == "")
            {
                Console.WriteLine("El nombre no puede estar vacío");
            }
        } while (nombreCliente.Trim() == "");

        //Fase 2. Selección del videojuego principal

        int opcionJuego;
        string tituloJuego;
        decimal precioJuego;
        bool hayStock = false;

        do
        {
            Console.WriteLine();
            Console.WriteLine("--- Catálogo de videojuegos ---");
            Console.WriteLine("1. Zelda: Ocarina Of Time: 59.99 euros (Stock: " + stockZelda + ")");
            Console.WriteLine("2. EA Sports FC 26: 49.99 euros (Stock: " + stockFifa + ")");
            Console.WriteLine("3. Leyendas pokémon: Z-A: 49.99 euros (Stock: " + stockPokemon + ")");
            Console.WriteLine("4. Assasins Creed Shadows: 34.99 euros (Stock: " + stockAssasinsCreed + ")");
            Console.Write("Selecciona un videojuego: ");
            opcionJuego = int.Parse(Console.ReadLine()!);

            if (opcionJuego < 1 || opcionJuego > 4)
            {
                Console.WriteLine("Debes seleccionar una opcion entre 1 y 4.");
            }
            else
            {
                //Comprobacion del stock
                if (opcionJuego == 1 && stockZelda > 0) hayStock = true;
                else if (opcionJuego == 2 && stockFifa > 0) hayStock = true;
                else if (opcionJuego == 3 && stockPokemon > 0) hayStock =true;
                else if (opcionJuego == 4 && stockAssasinsCreed > 0) hayStock =true;
                else
                {
                    Console.WriteLine("Lo sentimos, ese videojuego está agotado. Elige otro.");
                }
            }
        } while (opcionJuego < 1 || opcionJuego > 4 || !hayStock);
        if (opcionJuego == 1)
        {
            tituloJuego = "Zelda: Ocarina Of Time";
            precioJuego = 59.99m;
        }
        else if (opcionJuego == 2)
        {
            tituloJuego = "EA Sports FC 26";
            precioJuego = 49.99m;
        }
        else if (opcionJuego == 3)
        {
            tituloJuego = "Leyendas pokémon: Z-A";
            precioJuego = 49.99m;
        }
        else
        {
            tituloJuego = "Assasins Creed Shadows";
            precioJuego = 34.99m;
        }
        // Fase 3. Complementos y extras

        //Estas variables se reinician para cada venta
        bool tieneGarantia = false;
        bool tieneSuscripcionOnline = false;
        bool tieneFunda= false;
        bool tieneTarjetaRegalo = false;
        int opcionExtra;
        int cantidadExtra = 0;
        decimal precioExtra = 0;

        do
        {
            Console.WriteLine();
            Console.WriteLine("--- EXTRAS Y ACCESORIOS ---");
            Console.WriteLine("1. Garantía de protección de disco (1 año): 9.99 euros");
            Console.WriteLine("2. Suscripción online (3 meses): 14.99 euros");
            Console.WriteLine("3. Funda protectora de la consola: 14.99 euros");
            Console.WriteLine("4. Tarjeta regalo tienda (10 euros) 10.00 euros");
            Console.WriteLine("0. Terminar selección");
            Console.WriteLine();
            Console.WriteLine("Extras seleccionados: " + cantidadExtra);
            Console.WriteLine("Importe actual: " + (precioJuego + precioExtra).ToString("F2") + "euros");

            Console.WriteLine("Selecciona una opcion: ");
            opcionExtra = int.Parse(Console.ReadLine()!);

            if (opcionExtra == 1)
            {
                if (tieneGarantia)
                {
                    Console.WriteLine("Ya has añadido la garantía de protección.");
                }
                else
                {
                    tieneGarantia = true;
                    precioExtra += 9.99m;
                    cantidadExtra ++;
                    Console.WriteLine("Garantía añadida.");
                }
            }
            else if (opcionExtra == 2)
            {
                if (tieneSuscripcionOnline)
                {
                    Console.WriteLine("Ya has añadido la suscripción online.");
                }
                else
                {
                    tieneSuscripcionOnline = true;
                    precioExtra += 14.99m;
                    cantidadExtra ++;
                    Console.WriteLine ("Suscripción online (3 meses) añadida.");
                }
            }
            else if (opcionExtra == 3)
            {
                if (tieneFunda)
                {
                    Console.WriteLine("Ya has añadido la funda protectora");
                }
                else
                {
                    tieneFunda = true;
                    precioExtra += 14.99m;
                    cantidadExtra ++;
                    Console.WriteLine("Funda protectora añadida");
                }
            }
            else if(opcionExtra == 4)
            {
                if (tieneTarjetaRegalo)
                {
                    Console.WriteLine("Ya has añadido la tarjeta regalo");
                }
                else
                {
                    tieneTarjetaRegalo = true;
                    precioExtra += 10.00m;
                    cantidadExtra ++;
                    Console.WriteLine("Tarjeta regalo añadida");
                }
            }
            else if (opcionExtra != 0)
            {
                Console.WriteLine("Debes seleccionar una opcion entre 0 y 4");
            }
        } while (opcionExtra != 0);

    //Fase 4. FORMA DE ENTREGA

    int opcionEntrega;
    string formaEntrega;
    string direccion = "";
    decimal gastosEnvio = 0;

    do
    {
        Console.WriteLine();
        Console.WriteLine("--- Forma de entrega ---");
        Console.WriteLine("1. Recogida en tienda: gratis");
        Console.WriteLine("2. Envío a domicilio: 3,95 euros");
        Console.Write("Selecciona una opción: ");
        opcionEntrega = int.Parse(Console.ReadLine()!);

        if (opcionEntrega < 1 || opcionEntrega > 2)
        {
            Console.WriteLine("Debes seleccionar la opcion 1 o 2");
        }
    } while (opcionEntrega < 1 || opcionEntrega > 2);

    if (opcionEntrega == 1)
    {
        formaEntrega = "Recogida en tienda";
    }
    else
    {
        formaEntrega = "Envío a domicilio";
        gastosEnvio = 3.95m;

        do
        {
            Console.Write("Dirección de envio: ");
            direccion = Console.ReadLine() ?? "";

            if (direccion.Trim() == "")
            {
                Console.WriteLine("La dirección no puede estar vacía.");
            }
        } while (direccion.Trim() == "");
    }

    //Fase 5. Cálculo del importe y descuento

    decimal subtotalProductos = precioJuego + precioExtra;
    decimal descuento = 0;

    //Descuento del 10% si el gasto supera o iguala los 70€
    if (subtotalProductos >= 70m)
    {
        descuento = subtotalProductos * 0.10m;
    }

    decimal totalVenta = subtotalProductos - descuento + gastosEnvio;

    Console.WriteLine();
    Console.WriteLine("--- Resumen de la compra ---");
    Console.WriteLine("Videojuegos y extras: " + subtotalProductos.ToString("F2") + "euros");
    Console.WriteLine("Descuento (10% >= 70 euros): " + descuento.ToString("F2") + "euros");
    Console.WriteLine("TOTAL A PAGAR: " + totalVenta.ToString("F2") + "euros");


    // FASE 6. Cobro de la venta

    decimal importeEntregado;

    do
    {
        Console.Write("Importe entregado por el cliente: ");
        importeEntregado = Convert.ToDecimal(Console.ReadLine());

        if (importeEntregado < totalVenta)
        {
            Console.WriteLine(" Importe insuficiente, debes de introducir de nuevo el importe completo entregado");
        }
    } while (importeEntregado < totalVenta);

    decimal cambio = importeEntregado - totalVenta;

    // FASE 7. Actualización de caja y stock

    //Descontamos una unidad del stock del juego vendido
    if (opcionJuego == 1) stockZelda --;
    else if (opcionJuego == 2) stockFifa --;
    else if (opcionJuego == 3) stockPokemon --;
    else if (opcionJuego == 4) stockAssasinsCreed --;

    //Registro de la venta en la caja
    ventasRealizadas ++;
    recaudacion += totalVenta;

    if (ventasRealizadas == 1 || totalVenta > ventaMasCara)
        {
            ventaMasCara = totalVenta;
            clienteVentaMasCara = nombreCliente;
        }
    // FASE 8. Ticket de compra

    Console.WriteLine();
    Console.WriteLine("=====================================");
    Console.WriteLine("              GAMEHUB");
    Console.WriteLine("=====================================");
    Console.WriteLine("Número de ticket: " + ventasRealizadas);
    Console.WriteLine("Cliente: " + nombreCliente);
    Console.WriteLine("Videojuego: " + tituloJuego);
    Console.WriteLine("Extras adicionales:");

    if (cantidadExtra == 0)
        {
            Console.WriteLine("Ninguno");
        }
    else
    {
        if (tieneGarantia)
        {
            Console.WriteLine(" - Garantia de protección (1 Año)");
        }
        if (tieneSuscripcionOnline)
        {
            Console.WriteLine(" - Suscripción online (3 meses)");
        }
        if (tieneFunda)
        {
            Console.WriteLine(" - Funda de protección");
        }
        if (tieneTarjetaRegalo)
        {
            Console.WriteLine(" - Tarjeta regalo de la tienda (10 euros)");
        }
    }
    Console.WriteLine("Entrega: " + formaEntrega);

    if (opcionEntrega == 2)
    {
        Console.WriteLine("Dirección: " + direccion);
    }

    Console.WriteLine("--------------------------------");
    Console.WriteLine("Precio Videojuego: " + precioJuego.ToString("F2") + " euros");
    Console.WriteLine("Extras: " + precioExtra.ToString("F2") + " euros");
    Console.WriteLine("Subtotal: " + subtotalProductos.ToString("F2") + " euros");
    Console.WriteLine("Gastos de envío: " + gastosEnvio.ToString("F2") + " euros");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("TOTAL: " + totalVenta.ToString("F2") + " euros");
    Console.WriteLine("Entregado: " + importeEntregado.ToString("F2") + " euros");
    Console.WriteLine("Cambio: " + cambio.ToString("F2") + " euros");
    Console.WriteLine("===================================");
    Console.WriteLine("¡Gracias por comprar en GameHub!");
    }
    else if(opcionPrincipal == 2)
    {
        //Consulta de caja y control de almacen

        Console.WriteLine();
        Console.WriteLine("====================================");
        Console.WriteLine("      Caja del día y almacen");
        Console.WriteLine("====================================");

        if (ventasRealizadas == 0)
        {
            Console.WriteLine("Todavía no se ha realizado ninguna venta.");
        }
        else
        {
            decimal importeMedio = recaudacion / ventasRealizadas;

            Console.WriteLine("Ventas realizadas: " + ventasRealizadas);
            Console.WriteLine("Recaudación total: " + recaudacion.ToString("F2") + " euros");
            Console.WriteLine("Importe medio: " + importeMedio.ToString("F2") + " euros");
            Console.WriteLine("Venta mas cara: " + ventaMasCara.ToString("F2") + " euros");
            Console.WriteLine("Cliente de la venta más cara: " + clienteVentaMasCara);
        }
        Console.WriteLine("--------------------------------");
        Console.WriteLine("STOCK DISPONIBLE EN ALMACÉN");
        Console.WriteLine("- Zelda: Ocarina Of Time: " + stockZelda + " uds.");
        Console.WriteLine("- EA Sports FC 26: " + stockFifa + " uds.");
        Console.WriteLine("- Leyendas pokémon: Z-A: " + stockPokemon + " uds.");
        Console.WriteLine("- Assasins Creed Shadows: " + stockAssasinsCreed + " uds.");
    }
    else if(opcionPrincipal == 0)
    {
        Console.WriteLine();
        Console.WriteLine("Cerrando sistema de GameHub...");
        Console.WriteLine("Recaudación final: " + recaudacion.ToString("F2") + " euros");
        Console.WriteLine("¡Hasta pronto!");
    }
    else 
    {
        Console.WriteLine("Opción incorrecta, selecciona 1, 2 o 0");
    }
} while (opcionPrincipal !=0);