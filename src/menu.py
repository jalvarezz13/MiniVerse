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
        tierra_image = ImageTk.PhotoImage(file="src/images/tierra.gif")
        self.tierra = Label(self.canvas, image=tierra_image)
        self.tierra.place(x=25, y=125, bordermode="outside")


        #self.tierra = self.canvas.create_image(25, 125, image=tierra_image, anchor="w")
        #tierra = Button(self.canvas, image = tierra_image, background=)

        
        


        #self.ventana.wm_attributes('-transparentcolor', self.ventana['bg'])


        venus_image = ImageTk.PhotoImage(file="src/images/venus.png")
        self.venus=self.canvas.create_image(25, 450, image=venus_image, anchor="w")

        marte_image = ImageTk.PhotoImage(file="src/images/marte.png")
        self.marte=self.canvas.create_image(400, 125, image=marte_image, anchor="w")

        urano_image = ImageTk.PhotoImage(file="src/images/urano.png")
        self.urano=self.canvas.create_image(750, 125, image=urano_image, anchor="w")

        agujero_image = ImageTk.PhotoImage(file="src/images/agujeroNegro.png")
        self.agujero=self.canvas.create_image(750, 475, image=agujero_image, anchor="w")


        #Creamos la entidad que se desplaza por el lobby
        ovni_image = ImageTk.PhotoImage(file="src/images/ovni.png")
        self.ovni=self.canvas.create_image(500, 300, image=ovni_image, anchor="w")
        self.ventana.bind("<KeyPress>", self.presion_tecla)


        self.ventana.resizable(False, False)
        self.ventana.mainloop()

    def on_enter(self, event):
        print("Hola")

    def check_position(self):
        print()


    def presion_tecla(self, evento):
        if evento.keysym=='Right':
            self.canvas.move(self.ovni, 10, 0) #Aquí se ajusta la velocidad
        if evento.keysym=='Left':
            self.canvas.move(self.ovni, -10, 0)
        if evento.keysym=='Down':
            self.canvas.move(self.ovni, 0, 10)
        if evento.keysym=='Up':
            self.canvas.move(self.ovni, 0, -10)

        #check_position()

    


aplicacion=Aplicacion()