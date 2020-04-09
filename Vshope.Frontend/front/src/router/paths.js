/**
 * Define all of your application routes here
 * for more information on routes, see the
 * official documentation https://router.vuejs.org/en/
 */
export default [
  {
    path: '/home',
    name: 'common.home',
    view: 'Home'
  },
  {
    path: '/about',
    name: 'common.about',
    view: 'About'
  },
  {
    path: '/develop',
    name: 'common.develop',
    view: 'Develop'
  },
  {
    path: '/vkAuth',
    name: 'common.vkAuth',
    view: 'VkAuth'
  },
  {
    path: '/company-account-creator',
    name: 'common.companyAccountCreator',
    view: 'CompanyAccountCreator'
  },
  {
    path: '/company-manager',
    name: 'common.companyManager',
    view: 'CompanyManager'
  },
  {
    path: '/company/:companyId',
    name: 'common.company',
    view: 'Company',
    meta: {
      breadcrumbItems: [
        {
          text: 'common.companyManager',
          href: '/company-manager'
        },
        {
          text: 'common.company',
          href: '',
          disabled: true
        }
      ]
    }
  },
  {
    path: '/invoice-manager',
    name: 'common.invoiceManager',
    view: 'InvoiceManager'
  },
  {
    path: '/company-by-user-profile',
    name: 'companyProfile.name',
    view: 'CompanyByUserProfile'
  },
  {
    path: '/company-by-user-statistic',
    name: 'companyStatistic.name',
    view: 'CompanyByUserStatistic'
  },
  {
    path: '/company-by-user-invoices',
    name: 'companyInvoices.name',
    view: 'CompanyByUserInvoices'
  },
  {
    path: '/company-by-user-vk',
    name: 'companyVk.name',
    view: 'CompanyByUserVk'
  },
  {
    path: '/company-by-user-avito',
    name: 'companyAvito.name',
    view: 'CompanyByUserAvito'
  }
]
