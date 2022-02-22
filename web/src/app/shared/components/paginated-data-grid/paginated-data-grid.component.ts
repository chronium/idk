import { Component, OnInit } from '@angular/core';

export class DataGridCell {
  kind!: DataGridCellKind;
  text?: string;
  icon?: string;
}

export enum DataGridCellKind {
  Text = 'text',
  Icon = 'icon',
}

@Component({
  selector: 'idk-paginated-data-grid',
  templateUrl: './paginated-data-grid.component.html',
  styleUrls: ['./paginated-data-grid.component.scss'],
})
export class PaginatedDataGridComponent implements OnInit {
  headers = ['Name', 'Subdomain', 'Action'];

  data: DataGridCell[][] = this.mockData();

  constructor() {}

  ngOnInit(): void {}

  public iconPath(cell: DataGridCell): string {
    return (cell.icon?.endsWith('.svg') ? cell.icon : `${cell.icon}.svg`) ?? '';
  }

  mockData(): DataGridCell[][] {
    return [
      [
        {
          kind: DataGridCellKind.Text,
          text: "Hey, it's me!",
        },
        {
          kind: DataGridCellKind.Text,
          text: 'me',
        },
        {
          kind: DataGridCellKind.Icon,
          icon: 'fluent-icons/delete_24_regular',
        },
      ],
      [
        {
          kind: DataGridCellKind.Text,
          text: "You, that's you!",
        },
        {
          kind: DataGridCellKind.Text,
          text: 'you',
        },
        {
          kind: DataGridCellKind.Icon,
          icon: 'fluent-icons/delete_24_regular',
        },
      ],
    ];
  }
}
