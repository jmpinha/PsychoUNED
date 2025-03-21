import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { NotesPageComponent } from './pages/notes/notes-page.component';
import { SubjectsPage } from './pages/subjects/subjects-page.component';
import { AddDataPageComponent } from './pages/add-data/add-data.page';
import { TestsPageComponent } from './pages/tests/tests-page.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'calculadora',
        pathMatch: 'full',
    },
    {
        path: 'nuevosDatos',
        component: AddDataPageComponent
    },
    {
        path: 'asignaturas',
        component:SubjectsPage
    },
    {
        path: 'tests',
        component:TestsPageComponent
    },
    {
        path: 'calculadora',
        component:NotesPageComponent
    },
    // {
    //     path: 'notes',
    //     loadComponent: () =>
    //         import('./pages/notes/component/notes.page').then((m) => m.NotesPage),
    // },
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
