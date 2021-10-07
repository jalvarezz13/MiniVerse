import tkinter as tk
from tkinter import *
from PIL import Image, ImageTk
from tkinter import ttk

class Aplicacion:
    
    def __init__(self):
        #Inicializamos ventana
        self.ventana1=tk.Tk()
        self.canvas1= Canvas(self.ventana1, width= 1000, height= 600)

        #Añadimos el fondo
        self.canvas1.pack(expand=True, fill= BOTH)
        background= ImageTk.PhotoImage(file="src/images/background.png")
        self.canvas1.create_image(0, 0, image=background, anchor="nw")

        #Creamos la entidad que se desplaza por el lobby
        ovni_image = ImageTk.PhotoImage(file="src/images/ovni.png")
        self.ovni=self.canvas1.create_image(0, 0, image=ovni_image, anchor="nw")
        self.ventana1.bind("<KeyPress>", self.presion_tecla)
        
        self.ventana1.mainloop()       

    def presion_tecla(self, evento):
        if evento.keysym=='Right':
            self.canvas1.move(self.ovni, 10, 0) #Aquí se ajusta la velocidad
        if evento.keysym=='Left':
            self.canvas1.move(self.ovni, -10, 0)
        if evento.keysym=='Down':
            self.canvas1.move(self.ovni, 0, 10)
        if evento.keysym=='Up':
            self.canvas1.move(self.ovni, 0, -10)


aplicacion1=Aplicacion()