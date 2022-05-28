
private void ClearError_Click(object sender, EventArgs e)
        {
            if (PantallaEcuacion.Text == "Syntax Error")
                PantallaEcuacion.Text = "";
            else if(PantallaEcuacion.Text.Length!=0)
            {
                int len = PantallaEcuacion.Text.Length;
                if (PantallaEcuacion.Text[len - 1] == 'n' || PantallaEcuacion.Text[len - 1] == 's')
                {
                    if(PantallaEcuacion.Text[len - 2] == 'l')               //borrar ln
                    {
                        PantallaEcuacion.Text = PantallaEcuacion.Text.Remove(len - 2);
                    }
                    else                                                    //borrar trigonométricas 
                    {
                        PantallaEcuacion.Text = PantallaEcuacion.Text.Remove(len - 3);
                    }
                    if(len>5)       //evito error de índice no existente
                        if(PantallaEcuacion.Text[len - 5] == 'r')           //borrar trigonométricas inversas 
                        {
                            PantallaEcuacion.Text = PantallaEcuacion.Text.Remove(len - 6);
                        }
                }
                else if (PantallaEcuacion.Text[len - 1] == 'g')             //borrar log
                {
                    PantallaEcuacion.Text = PantallaEcuacion.Text.Remove(len - 3);
                }
                else if (PantallaEcuacion.Text[len - 1] == 'h')
                {
                    PantallaEcuacion.Text = PantallaEcuacion.Text.Remove(len - 4);
                    if (len > 5)
                        if (PantallaEcuacion.Text[len - 5] == 'r')
                            PantallaEcuacion.Text = PantallaEcuacion.Text.Remove(len - 6);
                }
                else
                {
                    PantallaEcuacion.Text = PantallaEcuacion.Text.Remove(PantallaEcuacion.Text.Length -1 );
                }
            }
        }

public const double PI = 3.1415926535897931;
        public const double E = 2.7182818284590451;
        
        /* ###########################################################
                                Función Intérpetre
           ########################################################### */
        string Interpreter(string expresion)
        {
            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i] == 'e')
                {
                    if (i != 0 && i < expresion.Length - 1)
                    {
                        if (Is_Number(expresion[i - 1]) && Is_Number(expresion[i + 1]))
                        {
                            expresion = expresion.Insert(i + 1, "" + E.ToString() + "");
                        }
                        else if (Is_Number(expresion[i - 1]))
                        {
                            expresion = expresion.Insert(i + 1, "*" + E.ToString());
                        }
                        else if (Is_Number(expresion[i + 1]))
                        {
                            expresion = expresion.Insert(i + 1, E.ToString() + "*");
                        }
                        else
                        {
                            expresion = expresion.Insert(i + 1, E.ToString());
                        }
                    }
                    else if (i == expresion.Length - 1 && expresion.Length > 1 && Is_Number(expresion[i - 1])) // "e" se encuentra al final de la expresion
                    {
                        expresion = expresion.Insert(i + 1, "*" + E.ToString());
                    }
                    else if (i == 0 && expresion.Length > 1 && Is_Number(expresion[i + 1])) // "e" se encuentra al inicio de la expresion
                    {
                        expresion = expresion.Insert(i + 1, E.ToString() + "*");
                    }
                    else            //e no tiene números al lado
                    {
                        expresion = expresion.Insert(i + 1, E.ToString());
                    }
                    expresion = expresion.Remove(i, 1);
                }
                if (expresion[i] == 'π')
                {
                    if (i != 0 && i < expresion.Length - 1)
                    {
                        if (Is_Number(expresion[i - 1]) && Is_Number(expresion[i + 1]))
                        {
                            expresion = expresion.Insert(i + 1, "" + PI.ToString() + "");
                        }
                        else if (Is_Number(expresion[i - 1]))
                        {
                            expresion = expresion.Insert(i + 1, "*" + PI.ToString());
                        }
                        else if (Is_Number(expresion[i + 1]))
                        {
                            expresion = expresion.Insert(i + 1, PI.ToString() + "*");
                        }
                        else
                        {
                            expresion = expresion.Insert(i + 1, PI.ToString());
                        }
                    }
                    else if (i == expresion.Length - 1 && expresion.Length > 1 && Is_Number(expresion[i - 1])) // "PI" se encuentra al final de la expresion
                    {
                        expresion = expresion.Insert(i + 1, "*" + PI.ToString());
                    }
                    else if (i == 0 && expresion.Length > 1 && Is_Number(expresion[i + 1])) // "PI" se encuentra al inicio de la expresion
                    {
                        expresion = expresion.Insert(i + 1, PI.ToString() + "*");
                    }
                    else            //e no tiene números al lado y da igual dónde esté
                    {
                        expresion = expresion.Insert(i + 1, PI.ToString());
                    }
                    expresion = expresion.Remove(i, 1);
                }

                if (expresion[i] == '(')//si encuentro un paréntesis
                {
                    int pos = i;
                    if (i != 0)
                        if (Is_Number(expresion[i - 1]))
                        {
                            expresion = expresion.Insert(i, "*");
                            pos = i + 1;
                        }
                    int parIzq = 1, parDer = 0;
                    while (parIzq != parDer)
                    {
                        pos++;
                        if (expresion[pos] == ')')
                            parDer++;
                        if (expresion[pos] == '(')
                            parIzq++;
                    }
                    if (pos != expresion.Length - 1)
                        if (Is_Number(expresion[pos + 1]))
                        {
                            expresion = expresion.Insert(pos + 1, "*");
                        }
                }
                if (expresion[i] == 'a'|| expresion[i] == 'l' || expresion[i] == 's' || expresion[i] == 'c' 
                    || expresion[i] == 't' && i!=0)
                {
                    if (Is_Number(expresion[i - 1]))
                    {
                        expresion = expresion.Insert(i ,"*");
                    }
                }
            }
            return expresion;
        }