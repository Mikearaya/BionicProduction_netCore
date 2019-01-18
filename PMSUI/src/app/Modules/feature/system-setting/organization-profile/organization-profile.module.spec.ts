import { OrganizationProfileModule } from './organization-profile.module';

describe('OrganizationModule', () => {
  let organizationModule: OrganizationProfileModule;

  beforeEach(() => {
    organizationModule = new OrganizationProfileModule();
  });

  it('should create an instance', () => {
    expect(organizationModule).toBeTruthy();
  });
});
