
import { inject } from '@angular/core';
import { ToastController } from '@ionic/angular';

export class Globals {
    private static toastController = inject(ToastController);

    static async showToast(word: string) {
      const toast = await this.toastController.create({
        message: `Este es un mensaje flotante ${word}`,
        duration: 3000,  // Se muestra por 3 segundos
        position: 'bottom' // Puedes usar 'top', 'middle' o 'bottom'
      });
  
      await toast.present();
    }
    
}
