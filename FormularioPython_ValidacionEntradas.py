# -*- coding: utf-8 -*-
"""
Created on Wed Sep 25 18:00:16 2024

@author: HP
"""

import tkinter as tk
from tkinter import messagebox

## Definición de funciones
def limpiar_campos():
    tbNombre.delete(0, tk.END)
    tbApellidos.delete(0, tk.END)
    tbEdad.delete(0, tk.END)
    tbEstatura.delete(0, tk.END)
    tbTelefono.delete(0, tk.END)
    var_genero.set(0)
    
def borrar_fun():
    limpiar_campos()
    
def guardar_valores():
        # Obtener valores desde los entrys
    nombres = tbNombre.get().strip()
    apellidos = tbApellidos.get().strip()
    edad = tbEdad.get().strip()
    estatura = tbEstatura.get().strip()
    telefono = tbTelefono.get().strip()
    
    # Validar que los campos no estén vacíos
    if not nombres or not apellidos or not edad or not estatura or not telefono:
        messagebox.showwarning("Advertencia", "Todos los campos son obligatorios.")
        return
    
    # Validar que la edad y la estatura sean números
    if not edad.isdigit() or not estatura.replace('.', '', 1).isdigit():
        messagebox.showwarning("Advertencia", "La edad y la estatura deben ser números válidos.")
        return
    
    # Validar que el teléfono sea numérico y de una longitud razonable
    if not telefono.isdigit() or len(telefono) < 9:
        messagebox.showwarning("Advertencia", "El teléfono debe contener al menos 9 dígitos numéricos.")
        return
    
    # Validar selección de género
    if var_genero.get() == 0:
        messagebox.showwarning("Advertencia", "Por favor, seleccione un género.")
        return
    
    # Obtener el género de los RadioButtons
    genero = "Hombre" if var_genero.get() == 1 else "Mujer"
        
    # Generar la cadena de caracteres
    datos = (
        "Nombres: " + nombres + "\n" +
        "Apellidos: " + apellidos + "\n" +
        "Edad: " + edad + " años\n" +
        "Estatura: " + estatura + "\n" +
        "Teléfono: " + telefono + "\n" +
        "Género: " + genero + "\n"
    )
    
    # Guardar los datos en el archivo TXT
    with open("302024Datos.txt", "a") as archivo:
        archivo.write(datos + "\n\n")
    
    # Mostrar mensaje de confirmación
    messagebox.showinfo("Información", "Datos guardados con éxito:\n\n" + datos)
    
    limpiar_campos()

## Creación de ventana
ventana = tk.Tk()
ventana.geometry("520x500")
ventana.title("Formulario Vr.02")

## Crear variable para el RadioButton
var_genero = tk.IntVar()

## Creación de etiquetas y campos de entrada
lbNombre = tk.Label(ventana, text="Nombres: ")
lbNombre.pack()
tbNombre = tk.Entry(ventana)
tbNombre.pack()

lbApellidos = tk.Label(ventana, text="Apellidos:")
lbApellidos.pack()
tbApellidos = tk.Entry(ventana)
tbApellidos.pack()

lbTelefono = tk.Label(ventana, text="Teléfono:")
lbTelefono.pack()
tbTelefono = tk.Entry(ventana)
tbTelefono.pack()

lbEdad = tk.Label(ventana, text="Edad:")
lbEdad.pack()
tbEdad = tk.Entry(ventana)
tbEdad.pack()

lbEstatura = tk.Label(ventana, text="Estatura:")
lbEstatura.pack()
tbEstatura = tk.Entry(ventana)
tbEstatura.pack()

lbGenero = tk.Label(ventana, text="Género:")
lbGenero.pack()

rbHombre = tk.Radiobutton(ventana, text="Hombre", variable=var_genero, value=1)
rbHombre.pack()
rbMujer = tk.Radiobutton(ventana, text="Mujer", variable=var_genero, value=2)
rbMujer.pack()

## Creación de botones
btnBorrar = tk.Button(ventana, text="Borrar valores", command=borrar_fun)
btnBorrar.pack()

btnGuardar = tk.Button(ventana, text="Guardar", command=guardar_valores)
btnGuardar.pack()

## Ejecución de ventana
ventana.mainloop()
