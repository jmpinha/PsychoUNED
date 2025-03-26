
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { IonApp, IonSplitPane, IonMenu, IonToggle, IonContent, IonList, IonListHeader, IonNote, IonMenuToggle, IonItem, IonIcon, IonLabel, IonRouterOutlet, IonRouterLink } from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { flowerOutline, bookOutline, checkboxOutline, calculatorOutline, addOutline } from 'ionicons/icons';
import { MenuNames } from './models/Names';
import { MatIconModule } from '@angular/material/icon';
import { ThemeService } from './services/theme.service';

@Component({
    selector: 'app-root',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.scss'],
    imports: [RouterLink, RouterLinkActive,
        IonApp,
        IonSplitPane,
        IonMenu,
        IonContent,
        IonList,
        IonListHeader,
        IonNote,
        IonMenuToggle,
        IonToggle,
        IonItem,
        IonIcon,
        IonLabel,
        IonRouterLink,
        IonRouterOutlet,
        MatIconModule
    ],
})
export class AppComponent {
    public appPages = [
        // { title: MenuNames.SUBJECTS, url: 'asignaturas', icon: 'flower' },
        // { title: MenuNames.NOTES, url: 'notes', icon: 'book' },
        { title: MenuNames.ADD_DATA, url: 'nuevosDatos', icon: 'add' },
        { title: MenuNames.TESTS, url: 'tests', icon: 'checkbox' },
        { title: MenuNames.GRADES, url: 'calculadora', icon: 'calculator' },
    ];
    public labels = ['Family', 'Friends', 'Notes', 'Work', 'Travel', 'Reminders'];
    get getTheme(){
        return this.themeService.isDarkMode();
    }
    constructor(private themeService: ThemeService) {
        addIcons({ flowerOutline, bookOutline, checkboxOutline, calculatorOutline,addOutline });
    }
    toggleDarkMode(event: any) {
        this.themeService.setDarkMode(event.detail.checked);
    }
}
