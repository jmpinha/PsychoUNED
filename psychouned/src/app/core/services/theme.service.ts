import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  private darkMode = false;

  constructor() {
    // Cargar la preferencia guardada
    const prefersDark = localStorage.getItem('dark-theme') === 'true';
    this.setDarkMode(prefersDark);
    console.log(this.isDarkMode())
  }

  setDarkMode(enable: boolean) {
    this.darkMode = enable;
    document.body.classList.toggle('dark-theme', enable);
    localStorage.setItem('dark-theme', enable.toString());
  }

  isDarkMode(): boolean {
    return this.darkMode;
  }

}
