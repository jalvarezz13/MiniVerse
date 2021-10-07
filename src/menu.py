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
        
        #Creacion de planetas
        tierra_image = ImageTk.PhotoImage(file="src/images/tierra.png")
        self.ovni=self.canvas.create_image(50, 150, image=tierra_image, anchor="w")

        venus_image = ImageTk.PhotoImage(file="src/images/venus.png")
        self.ovni=self.canvas.create_image(100, 300, image=venus_image, anchor="w")

        marte_image = ImageTk.PhotoImage(file="src/images/marte.png")
        self.ovni=self.canvas.create_image(200, 50, image=marte_image, anchor="w")

        urano_image = ImageTk.PhotoImage(file="src/images/urano.png")
        self.ovni=self.canvas.create_image(500, 350, image=urano_image, anchor="w")


        #Creamos la entidad que se desplaza por el lobby
        ovni_image = ImageTk.PhotoImage(file="src/images/ovni.png")
        self.ovni=self.canvas.create_image(500, 300, image=ovni_image, anchor="w")
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