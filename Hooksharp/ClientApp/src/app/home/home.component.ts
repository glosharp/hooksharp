import { Component } from '@angular/core';
export class Tile {
  value: string
  cols: number;
  rows: number;
  title: string;
  logoUrl: string;
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  parsed = false;
  parsedWebhook: string;
  providerTiles: Tile[] = [
    {title: 'Discord', cols: 2, rows: 2, value: 'discord', logoUrl: 'https://discord.com/assets/fc0b01fe10a0b8c602fb0106d8189d9b.png'},
    {title: 'Microsoft Teams', cols:2, rows: 2, value: 'msteams', logoUrl: 'https://lefthook.com/wp-content/uploads/ms-teams400x200.png'},
  ]

  handlerTiles: Tile[] = [
    {title: 'Bitbucket Server', cols: 2, rows: 2, value: 'bitbucketserver', logoUrl: 'https://www.nicepng.com/png/detail/321-3210484_atlassian-bitbucket-logo.png'}
  ]

  selectedProviderTile = new Tile();
  selectedHandlerTile = new Tile();


  onProviderClick(provider: Tile) {
    this.selectedProviderTile = provider;
  }

  onHandlerClick(handler: Tile) {
    this.selectedHandlerTile = handler;
  }

  getProviderTitle() {
    if (this.selectedProviderTile.title) {
      return this.selectedProviderTile.title;
    } else {
      return 'No Provider Selected';
    }
  }

  onParseClick() {
    this.parsedWebhook = this.parse();
    this.parsed = true;
  }

  onStartOverClick() {
    this.parsedWebhook = '';
    this.selectedHandlerTile = new Tile();
    this.selectedProviderTile = new Tile();
    this.parsed = false;
  }

  parse(): string {
    if (this.selectedProviderTile.value === 'discord') {
      return 'https://hook.glosharp.com/webhooks/discord/bitbucket-server/1234/adefws';
    }

    if (this.selectedProviderTile.value === 'msteams') {
      return 'https://hook.glosharp.com/webhooks/teams/bitbucket-server/asdf@1234/xyz';
    }
  }

}
