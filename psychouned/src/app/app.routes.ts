import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { SubjectsPage } from './pages/subjects/component/subjects.page';
import { NotesPage } from './pages/notes/component/notes.page';
import { TestsPage } from './pages/tests/component/tests.page';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'calculadora',
        pathMatch: 'full',
    },
    {
        path: 'nuevosDatos',
        loadComponent: () =>
            import('./pages/add-data/component/add-data.page').then((m) => m.AddDataPage),
    },
    {
        path: 'asignaturas',
        loadComponent: () =>
            import('./pages/subjects/component/subjects.page').then((m) => m.SubjectsPage),
    },
    // {
    //     path: 'notes',
    //     loadComponent: () =>
    //         import('./pages/notes/component/notes.page').then((m) => m.NotesPage),
    // },
    {
        path: 'tests',
        loadComponent: () =>
            import('./pages/tests/component/tests.page').then((m) => m.TestsPage),
    },
    {
        path: 'calculadora',
        loadComponent: () =>
            import('./pages/grades/component/grades.page').then((m) => m.GradesPage),
    },
  {
    path: 'add-data',
    loadComponent: () => import('./pages/add-data/component/add-data.page').then( m => m.AddDataPage)
  }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
