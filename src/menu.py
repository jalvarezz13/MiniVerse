import tkinter as tk
from tkinter import *
from PIL import Image, ImageTk

class Aplicacion:
    
    def __init__(self):
        #Inicializamos ventana
        self.ventana=tk.Tk()
        self.canvas= Canvas(self.ventana, width= 1000, height= 600)

        #Añadimos el fondo
        self.canvas.pack(expand=True, fill= BOTH)
        background= ImageTk.PhotoImage(file="src/images/background.png")
        self.canvas.create_image(0, 0, image=background, anchor="nw")

        #Creamos la entidad que se desplaza por el lobby
        ovni_image = ImageTk.PhotoImage(file="src/images/ovni.png")
        self.ovni=self.canvas.create_image(200, 200, image=ovni_image, anchor="w")
        self.ventana.bind("<KeyPress>", self.presion_tecla)
        
        self.ventana.resizable(False, False)
        self.ventana.mainloop()

    def presion_tecla(self, evento):
        if evento.keysym=='Right':
            self.canvas.move(self.ovni, 10, 0) #Aquí se ajusta la velocidad
        if evento.keysym=='Left':
            self.canvas.move(self.ovni, -10, 0)
        if evento.keysym=='Down':
            self.canvas.move(self.ovni, 0, 10)
        if evento.keysym=='Up':
            self.canvas.move(self.ovni, 0, -10)


aplicacion1=Aplicacion()