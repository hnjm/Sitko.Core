# [8.2.0](https://github.com/sitkoru/Sitko.Core/compare/8.1.0...8.2.0) (2021-09-06)


### Features

* **blazor:** add after initialization hooks to BaseComponent ([8ab75ff](https://github.com/sitkoru/Sitko.Core/commit/8ab75ff7385e4b1cf037df2abfb35f77b5b6e41e))

# [8.1.0](https://github.com/sitkoru/Sitko.Core/compare/8.0.1...8.1.0) (2021-09-06)


### Features

* **grpc:** add option to configure WebHost/Kestrel for gRPC server module ([f2a64e2](https://github.com/sitkoru/Sitko.Core/commit/f2a64e27ea2b9c70f4117d42fcc8096e992d48da))

## [8.0.1](https://github.com/sitkoru/Sitko.Core/compare/8.0.0...8.0.1) (2021-09-05)


### Bug Fixes

* **app:** require logging and configuration modules to implement interface so we run options validation only when needed ([4c3a0e7](https://github.com/sitkoru/Sitko.Core/commit/4c3a0e703494f7903e7b9339483fcdc4f0b802cf))

# [8.0.0](https://github.com/sitkoru/Sitko.Core/compare/7.22.0...8.0.0) (2021-09-03)


### Bug Fixes

* **app:** force validate module options on logging and services configuration steps only ([49907d2](https://github.com/sitkoru/Sitko.Core/commit/49907d296bc26f03a121bf64f716c00612ef15e0))
* **app:** return run command to supported list ([5bc1cc2](https://github.com/sitkoru/Sitko.Core/commit/5bc1cc212a4190dcfd88f43d46a4a513c2d9513a))
* **app:** rework commands implementation ([cd289bb](https://github.com/sitkoru/Sitko.Core/commit/cd289bb6648882322257b68dd7f34e5b0504664d))
* **app:** throw OptionsValidationException on module options validation failure ([7fb160a](https://github.com/sitkoru/Sitko.Core/commit/7fb160ac58f46d785f2117d2615ec4f3aad4dd60))
* **blazor:** don't add change for new entity ([888acab](https://github.com/sitkoru/Sitko.Core/commit/888acab7a3777f5df725bbc153bd3d92e4fb047a))
* **blazor:** notify state change on form validation change ([e64d22c](https://github.com/sitkoru/Sitko.Core/commit/e64d22c101d0689c54073e6852f6961594f9fb89))
* **blazor:** recalculate form state on reset ([60a0e4f](https://github.com/sitkoru/Sitko.Core/commit/60a0e4f4b54a6babe1fc42a384923000a970d7ec))
* **blazor:** remove old code ([191a969](https://github.com/sitkoru/Sitko.Core/commit/191a9692440886c2bb6a0ad09680f608c796bbdd))
* **blazor:** reset repository form on EntityId parameter change ([464fe9c](https://github.com/sitkoru/Sitko.Core/commit/464fe9c3fef799375e1d097af0f0a7d61aec3ab7))
* **blazor:** set currentEntityId after initialization ([6a10471](https://github.com/sitkoru/Sitko.Core/commit/6a104718ccd328e27dbe25295f669014bff0a39f))
* **blazor:** use JsonHelper for debug form view ([dde0d72](https://github.com/sitkoru/Sitko.Core/commit/dde0d72eafdc143e085e1cd4589c9dcd6c9c6744))
* **blazor:** use old parameter value to decide if form needs reset ([56f8d14](https://github.com/sitkoru/Sitko.Core/commit/56f8d141280652abfe132b7dab6ede0eed01c4a4))
* **ci:** fix blazor workflow paths ([99b0407](https://github.com/sitkoru/Sitko.Core/commit/99b040735cb9bfd57af20453235f9ee503aae59a))
* **ci:** one more time ([99d8e49](https://github.com/sitkoru/Sitko.Core/commit/99d8e49dbfb2fad431c819424b1f1384160f1d3d))
* **ci:** run semantic-release on public runner ([35056fc](https://github.com/sitkoru/Sitko.Core/commit/35056fc39880bc409b3d31bb36e8431d7f9dba7d))
* **demo:** raise log level ([d14f4ff](https://github.com/sitkoru/Sitko.Core/commit/d14f4ffef8f05909231b739dc8ea870af5d2adee))
* **demo:** rework edit page demo ([21544ba](https://github.com/sitkoru/Sitko.Core/commit/21544baa2d6693f3de0223840f6965a11c827eb3))
* **demo:** upd demo layout ([d65fa76](https://github.com/sitkoru/Sitko.Core/commit/d65fa761e25a05498a0978ec2119c66cb41fafaf))
* **fluentvalidation:** rework validator to support disposing ([0745f58](https://github.com/sitkoru/Sitko.Core/commit/0745f58b6e5345ebd307ca216568591c5db62cb1))
* **repository:** always copy current collection value for change entry ([80682f0](https://github.com/sitkoru/Sitko.Core/commit/80682f0165a02b5e667b72bd2dda6602dbdfddba))
* **repository:** detach all skip navigation subentities before load collection from db ([c99b82b](https://github.com/sitkoru/Sitko.Core/commit/c99b82b9a38b00fbfa004a879ad0c1118cd1e87e))
* **repository:** fix attaching external entities graph to dbContext ([5d04ad2](https://github.com/sitkoru/Sitko.Core/commit/5d04ad2e90d5b25318d33e1ff74a4d786e7d5f7d))
* **repository:** fix change state detection for whole entity ([ec6df27](https://github.com/sitkoru/Sitko.Core/commit/ec6df273606963522a626e82e06039f29eb04c14))
* **repository:** force load collection value from database instead of setting it to null ([bc612d1](https://github.com/sitkoru/Sitko.Core/commit/bc612d1166260dd999c95b81f140829ebff8676e))
* **repository:** if there is no changes - we must return Unchanged ([5559ae5](https://github.com/sitkoru/Sitko.Core/commit/5559ae52cf5e800f37f132fb3d61bd8aa74426e4))
* **repository:** process skip navigations only once ([33a6988](https://github.com/sitkoru/Sitko.Core/commit/33a69889fcb09da2adc8d4c86875dc42f5caf208))
* **repository:** skip fixups only if there is no changes inside ([f1d9b88](https://github.com/sitkoru/Sitko.Core/commit/f1d9b88f05273005251c48b59070bf795f65ca89))
* **vault:** fix token renew. add more logs. ([51b051e](https://github.com/sitkoru/Sitko.Core/commit/51b051e8ca3565274cecae1b2f779e43b73550be))


### Features

* v8 release ([79e39da](https://github.com/sitkoru/Sitko.Core/commit/79e39da312baf360d14f10cfe86be78db599e23d))
* **antblazor:** add AntFormItem component with hint support ([6c2e5a1](https://github.com/sitkoru/Sitko.Core/commit/6c2e5a1d69d73f9b2e8fb569fd03a524cf44fb4a))
* **antblazor:** add debug view for ant forms ([8356888](https://github.com/sitkoru/Sitko.Core/commit/83568886d9b30d1046f0e72c01a1b50569a076de))
* **app:** always try to validate module options on creation ([6965e4f](https://github.com/sitkoru/Sitko.Core/commit/6965e4f863c8e4da6f9c4040a98b1c1527f52c06))
* **auth:** add basic auth module options validation ([2e7dfcf](https://github.com/sitkoru/Sitko.Core/commit/2e7dfcfac5fcb94de5669e1ec569e027e57b6060))
* **auth:** unify auth modules and their options ([e271d90](https://github.com/sitkoru/Sitko.Core/commit/e271d904935e55b484a73995fa887110a17f4c3c))
* **blazor:** add additional information into list sort and filters about properties and values ([f7561fd](https://github.com/sitkoru/Sitko.Core/commit/f7561fd97e185896f4ae83ac2343693da58a4554))
* **blazor:** add EditorRequired attribute where possible ([80586a7](https://github.com/sitkoru/Sitko.Core/commit/80586a75069baf15567582e00192a2622900c9e4))
* **blazor:** move localization provider injection to BaseComponent ([dc7f5b5](https://github.com/sitkoru/Sitko.Core/commit/dc7f5b5197034ed8fb5669f5545390955c6c4e71))
* **blazor:** original entity value should come from different repository ([898fcfa](https://github.com/sitkoru/Sitko.Core/commit/898fcfab3c93e26d99787d6be3c8133a81c7c0d1))
* **blazor:** redo ant lists, create base list with markup and then inherit repository list from it ([7f847a9](https://github.com/sitkoru/Sitko.Core/commit/7f847a92e4142732b4603d0567c8fef2f72af31d))
* **demo:** demo AntFormItem with hint ([9582522](https://github.com/sitkoru/Sitko.Core/commit/9582522795e8978ad6526cfb02c5f1592fe07f88))
* **demo:** demo form debug and reset ([de73552](https://github.com/sitkoru/Sitko.Core/commit/de73552abf2398b5fb451fd41f359255590a6d22))
* **grpc:** add ErrorsString to ApiResponseError for simpler logging ([0051e80](https://github.com/sitkoru/Sitko.Core/commit/0051e80b3a65d236befd30f206784b9171a181ae))
* **grpc:** add IsSuccess shortcut to IGrpcResponse ([213c5d3](https://github.com/sitkoru/Sitko.Core/commit/213c5d38aa2d3ebf6cbe70aead60ff60402105e6))
* **grpc:** allow separate options per grpc client ([a059a2d](https://github.com/sitkoru/Sitko.Core/commit/a059a2de6352d4297921211b995a21e63947909e))
* **grpc:** don't need TRequest generic parameter, accept any IGrpcRequest ([159d4d6](https://github.com/sitkoru/Sitko.Core/commit/159d4d67fec0bd3bcc4a760bc27e87c9c46e62f9))
* **repository:** add more operators to repository conditions ([07bc24f](https://github.com/sitkoru/Sitko.Core/commit/07bc24fa69d5bb9109a2ae4a42ef08eb3a2688b1))
* **repository:** back to attaching entity to context on external update ([05e773d](https://github.com/sitkoru/Sitko.Core/commit/05e773d356b788e00ade34ff1a101d7ad32b62d4))
* **repository:** improve updating external entities ([5099e5e](https://github.com/sitkoru/Sitko.Core/commit/5099e5e78fca93170f2265489ef31437bf95cb68))
* **web:** remove razor runtime compilation from core. target application should handle it. ([7e244e7](https://github.com/sitkoru/Sitko.Core/commit/7e244e7243e3a4dc57852a6d1f87d8bd86e97468))


### Performance Improvements

* **repository:** use Any to improve performance ([ea47ab2](https://github.com/sitkoru/Sitko.Core/commit/ea47ab2357abbe474dc9c1917b076adf6c7be420))


### BREAKING CHANGES

* v8!