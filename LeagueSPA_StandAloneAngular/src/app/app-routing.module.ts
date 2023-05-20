import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AbilitiesComponent } from './abilities/abilities.component';
import { ChampionsComponent } from './champions/champions.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'champions', component: ChampionsComponent },
  { path: 'abilities', component: AbilitiesComponent },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
