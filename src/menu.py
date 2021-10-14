import tkinter as tk
from tkinter import *
from PIL import Image, ImageTk

class Aplicacion:
    
    def __init__(self):
        #Inicializamos ventana
        self.ventana=tk.Tk()
        self.canvas= Canvas(self.ventana, width = 1000, height = 600)
        self.ventana.bind('<Motion>', self.motion)

        #Añadimos el fondo
        self.canvas.pack(expand=True, fill= BOTH)
        background= ImageTk.PhotoImage(file="src/images/background.jpg")
        self.canvas.create_image(0, 0, image=background, anchor="nw")
        
        #Creacion de planetas
        bloque1_image = ImageTk.PhotoImage(file="src/images/amarillo.jpg")
        self.bloque1 = Button(self.canvas, image=bloque1_image)
        self.bloque1.place(x=25, y=25)

        bloque2_image = ImageTk.PhotoImage(file="src/images/amarillo.jpg")
        self.bloque2 = Button(self.canvas, image=bloque1_image)
        self.bloque2.place(x=425, y=25)

        bloque3_image = ImageTk.PhotoImage(file="src/images/amarillo.jpg")
        self.bloque3 = Button(self.canvas, image=bloque1_image)
        self.bloque3.place(x=800, y=25)

        bloque4_image = ImageTk.PhotoImage(file="src/images/amarillo.jpg")
        self.bloque4 = Button(self.canvas, image=bloque1_image)
        self.bloque4.place(x=25, y=375)


        #Creamos la entidad que se desplaza por el lobby
        mario_image = ImageTk.PhotoImage(file="src/images/mario.png")
        self.mario=self.canvas.create_image(500, 300, image=mario_image)
        
        self.ventana.bind("<KeyPress>", self.presion_tecla)

        self.ventana.resizable(False, False)
        self.ventana.mainloop()


    def presion_tecla(self, evento):
        
        if evento.keysym=='Right':
            self.canvas.move(self.mario, 10, 0) #Aquí se ajusta la velocidad
        if evento.keysym=='Left':
            self.canvas.move(self.mario, -10, 0)
        if evento.keysym=='Down':
            self.canvas.move(self.mario, 0, 10)
        if evento.keysym=='Up':
            self.canvas.move(self.mario, 0, -10)

    def motion(self, evento):
        x, y = evento.x, evento.y
        print('{}, {}'.format(x, y))

        



aplicacion=Aplicacion()