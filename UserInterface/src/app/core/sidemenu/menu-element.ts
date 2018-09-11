export const menus = [
  {
    'name': 'Dashboard',
    'icon': 'dashboard',
    'link': '/auth/dashboard',
    'open': false,
    'chip': { 'value': 1, 'color': 'accent' },
  },
  {
    'name': 'Production',
    'icon': 'widgets',
    'link': false,
    'open': false,
    'sub': [
      {
        'name': 'New Order',
        'link': 'material-widgets/buttons',
        'icon': 'indeterminate_check_box',
        'chip': false,
        'open': false,
      },
      {
        'name': 'Work Orders',
        'link': 'workorders',
        'icon': 'list',
        'chip': false,
        'open': false,
      },
      {
        'name': 'Add Finished Orders',
        'link': 'material-widgets/list',
        'icon': 'list',
        'chip': false,
        'open': false,
      }
    ]
  },
  {
    'name': 'Products',
    'icon': 'list',
    'link': 'products',
    'open': false,
    'chip': { 'value': 2, 'color': 'accent' }

  },
  {
    'name': 'Sales',
    'icon': 'mode_edit',
    'link': '/auth/guarded-routes',
    'open': false,
  },
  {
    'name': 'Employees',
    'icon': 'mode_edit',
    'link': 'employees',
    'open': false,
  },
  {
    'name': 'Clients',
    'icon': 'mode_edit',
    'link': 'customers',
    'open': false,
  }
];
