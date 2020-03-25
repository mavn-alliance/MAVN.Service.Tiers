DECLARE @default_tier_id uniqueidentifier = 'e5538c22-3f19-489a-8eed-0549b84a47d2';

INSERT INTO tiers.customer_tiers (customer_id, tier_id)
SELECT CAST(customer_id as uniqueidentifier), @default_tier_id AS tier_id
FROM customer_profile.customer_profile
WHERE
	TRY_CONVERT(uniqueidentifier, customer_id) IS NOT NULL AND
	NOT EXISTS (
				SELECT customer_id
				FROM tiers.customer_tiers
				WHERE tiers.customer_tiers.customer_id = CAST(customer_profile.customer_profile.customer_id as uniqueidentifier)
				);